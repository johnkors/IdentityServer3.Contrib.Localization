master:[![master](https://ci.appveyor.com/api/projects/status/5o9shqnmao5ln18w/branch/master?svg=true)](https://ci.appveyor.com/project/JohnKorsnes/identityserverv3-contrib/branch/master)
dev:[![dev](https://ci.appveyor.com/api/projects/status/5o9shqnmao5ln18w/branch/dev?svg=true)](https://ci.appveyor.com/project/JohnKorsnes/identityserverv3-contrib/branch/dev)
[![NuGet Stable](http://img.shields.io/nuget/v/IdentityServer3.Localization.svg?style=flat)](https://www.nuget.org/packages/IdentityServer3.Localization/)
[![NuGet Prerelease](https://img.shields.io/nuget/vpre/IdentityServer3.Localization.svg)](https://www.nuget.org/packages/IdentityServer3.Localization/)
[![Downloads](https://img.shields.io/nuget/dt/IdentityServer3.Localization.svg)](https://www.nuget.org/packages/IdentityServer3.Localization/)

# Contents

Implementation of IdentityServerV3s ILocalizationService


## Usage

```
   var options = new LocaleOptions { Locale = "nb-NO" };
   var eventService = new GlobalizedLocalizationService(options);
```

## Install

```
  PM> Install-Package IdentityServer3.Localization
```

NuGet:
https://www.nuget.org/packages/IdentityServer3.Localization


## Dependencies

 * Thinktecture.IdentityServer3 - http://www.nuget.org/packages/Thinktecture.IdentityServer3/
