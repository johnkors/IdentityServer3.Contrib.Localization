
properties {
    $githubRepo = 'IdentityServer3.Contrib.Localization';
    $base_dir = resolve-path .
    $src_dir = "$base_dir\source";
    $packages_dir = "$src_dir\packages";
    $config = 'debug';
	$sln = "$src_dir\Contrib.sln";
    $build_version = "$(get-date -Format "yyyy_MM_dd_")$(get-random -Maximum 100000)";
    $runsOnBuildServer = $false;
    $dist_dir = "$base_dir\dist";
    $test_report_dir = "$base_dir\TestResult";
    $publishUri = $null;
    $publishUsername = $null;
    $publishPassword = $null;
    $publishApiKey = $null
}

Import-module "$psscriptroot\tools\teamcity.psm1" -WarningAction SilentlyContinue

FormatTaskName {
    param($taskName)
    write-host "Executing Task: $taskName" -foregroundcolor Magenta
}

task -name validate-config -depends add-teamcity-reporting -action {
    assert ( 'debug', 'release' -contains $config) "Invalid config: $config. Should be 'debug' or 'release'"
    Write-host "Build version is $build_version"
    Write-host "Configuration is $config"
    Write-host "Running on build server: $runsOnBuildServer"
    if (-not(test-path -pathtype container -path $dist_dir)) { md $dist_dir | out-null }
}

task -name rebuild -depends clean, build 

task -name ensure-nuget -action {
    exec {
        nuget update -self
    }
}

task -name restore-nuget -depends ensure-nuget -action {
	exec {
		nuget restore $sln
	}
}

task -name patch-assemblyinfo -precondition { return $runsOnBuildServer } -action {
    exec {
        Write-host "Patching assembly version, setting version to $build_version"
    
        function PatchFile ([string] $pattern, [string] $replaceString, [string] $fullPath){
            (gc $fullPath) -replace $pattern, $replaceString | out-file $fullPath
        }
    
        find_assemblyinfo | % {
            $assemblyVersionPattern = 'AssemblyVersion\(".+?"\)' 
            $assembyVersionReplacement ='AssemblyVersion("' + $build_version + '")'
            PatchFile $assemblyVersionPattern $assembyVersionReplacement $_
    
            $assemblyFileVersionPattern = 'AssemblyFileVersion\(".+?"\)' 
            $assembyFileVersionReplacement ='AssemblyFileVersion("' + $build_version + '")'
            PatchFile $assemblyFileVersionPattern $assembyFileVersionReplacement $_
        }    
    }
}

task -name build-sln -depends validate-config, restore-nuget, patch-assemblyinfo -action {
    exec {
        run-msbuild $sln 'build' $config
    }
}

task -name clean -depends validate-config -action {
    exec {
        run-msbuild $sln 'clean' $config
    }
}

task -name ensure-xunit -action {
    exec {
        if (-not(gci -Path $packages_dir -Filter xunit.runner.console*)) {
            nuget install xunit.runner.console -SolutionDirectory $src_dir      
        }
    }
}

task -name add-teamcity-reporting -precondition { return $runsOnBuildServer } -action {
    exec {
        TaskSetup {
            $taskName = $psake.context.Peek().currentTaskName
            $global:pasPakkerBuildResult = "##teamcity[buildStatus status='FAILURE' text='Build failed on step $taskName']"
            TeamCity-ReportBuildProgress "Running task $taskName"
        }
    }
}

task -name run-unittests -depends build, ensure-xunit -action {
    exec {
        run_tests "$src_dir\Unittests\bin\$config\Unittests.dll" `
            "$test_report_dir\$($build_version)_integration_TestResult.xml"
    }
}

task -name run-tests -depends run-unittests

task -name ci -depends run-tests -action {
    exec {
        $global:pasPakkerBuildResult = $null
    }
}

task -name run-octopack -depends clean,run-tests -action {
    exec {
        run-msbuild $sln 'build' $config $true
    }
}

task -name list-publishable-artifacts -action {
    exec {
        find-publishable-artifacts | %{ Rename-item (join-path $dist_dir $_.Name) "Local.$($_.Name)" }
        find-publishable-artifacts | %{ Write-host "Artifact: $($_.FullName)"}
    }
}

task -name ensure-publish-credentials -depends ensure-nuget -action {
    exec {
        if (-not((nuget sources list|out-string).Contains('udir-nuggets-publish'))) {
            Write-host "Adding feed udir-nuggets-publish with value $publishUri"
            $sourcesCmd = 'add'
        } else {
            Write-host "Updating credentials for 'udir-nuggets-publish'"
            $sourcesCmd = 'update'
        }
        nuget sources $sourcesCmd -Name 'udir-nuggets-publish' -source $publishUri `
            -Username $publishUsername -Password $publishPassword
    }
}

task -name publish-to-feed -precondition { return ($publishUri -ne $null)} `
        -depends ensure-publish-credentials -action {
    exec {
        find-publishable-artifacts | %{
            Write-host "Publishing $($_.FullName) to $publishUri"
            nuget push $_.FullName $publishApiKey -Source $publishUri -Verbosity detailed
        }
    }
}

task -name dist -depends run-octopack,list-publishable-artifacts, publish-to-feed -action {
    exec {
        $global:pasPakkerBuildResult = $null
    }
}

task build -depends build-sln
task default -depends build-sln

########### Helper functions ########################

function run-msbuild($sln_file, $t, $cfg, $runOctopack=$false) {
    $v = if ($runsOnBuildServer) { 'n'} else { 'q' } 
    Framework '4.5.1'
    msbuild /nologo /verbosity:$v $sln_file /t:$t /p:Configuration=$cfg /p:RunOctoPack=$runOctopack `
        /p:OctoPackPublishPackageToFileShare=$dist_dir
}

function xunit_console_runner {
    $xunit_dir = gci -Path "$src_dir\packages" -Filter xunit.console.runner* | sort -Property Name | select -Last 1
    gci -Path $xunit_dir.fullname -Filter xunit.console.exe -Recurse | select -First 1 -ExpandProperty FullName
}

function run_tests($testassemblies, $reportfile, $suiteName) {
    if ($runsOnBuildServer) { TeamCity-TestSuiteStarted $suiteName }
    if (-not(test-path $test_report_dir)) { md $test_report_dir | out-null }
    #$devNull = [System.IO.Path]::GetTempFileName()
    & (xunit_console_runner) $testassemblies -nunit $reportfile
    if ($runsOnBuildServer) { 
        Write-output "##teamcity[importData type='nunit' path='$reportfile']" 
        TeamCity-TestSuiteFinished $suiteName
    } else {
        Write-output "Saved test report to $reportfile"
    }
}

function find_assemblyinfo {
    Get-ChildItem -Path $src_dir `
        | ?{$_.PSIsContainer} `
        | %{ Get-ChildItem -Path $_.FullName -Filter Properties} `
        | %{ Get-ChildItem -Path $_.FullName -Filter AssemblyInfo.cs} `
        | select -ExpandProperty FullName
}

function find-publishable-artifacts {
    $filter = "*$($build_version).?.nupkg"
    Write-host "Searching for publishable artifacts: $filter in $dist_dir"
    gci -Path $dist_dir -Filter $filter
}
