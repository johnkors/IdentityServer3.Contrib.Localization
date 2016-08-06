| master | dev | latest |
| --- | --- | --- |
| [![master](https://ci.appveyor.com/api/projects/status/63g2yulmxod35vd1/branch/master?svg=true)](https://ci.appveyor.com/project/JohnKorsnes/identityserver3-contrib-localization/branch/master) | [![dev](https://ci.appveyor.com/api/projects/status/63g2yulmxod35vd1/branch/dev?svg=true)](https://ci.appveyor.com/project/JohnKorsnes/identityserver3-contrib-localization/branch/dev) | [![NuGet Stable](http://img.shields.io/nuget/v/IdentityServer3.Localization.svg?style=flat)](https://www.nuget.org/packages/IdentityServer3.Localization/)|

# Contents
Implementation of IdentityServerV3's ILocalizationService.

### What does it translate?
  - Resource strings defined by IdentityServer. See [a list of defined resources here.](http://johnkors.github.io/IdentityServer3.Contrib.Localization/#/Default)
  - If what you want to translate is not defined by those resources, you would need to implement it yourself.

## Usage

- Specific culture:
```
   var options = new LocaleOptions { Locale = "nb-NO" };
   var localizationService = new GlobalizedLocalizationService(options);
```

- To use IdentityServer3s default provided localization:
```
   var localizationService = new GlobalizedLocalizationService();
```

- Pirate culture:
```
   var options = new LocaleOptions { Locale = "pirate" }; // ye be warned!
   var localizationService = new GlobalizedLocalizationService(options);
```


## Supported languages
 * See the [live docs of all translations](http://johnkors.github.io/IdentityServer3.Contrib.Localization/#/Default)

## Install

```
  PM> Install-Package IdentityServer3.Localization
```

NuGet:
https://www.nuget.org/packages/IdentityServer3.Localization


## Contributing

How to add another language:

 * Fork the repo
 * Add the following resource files for your language in the resource folder (for instance by copying the default). ISO codes can be found [here])https://msdn.microsoft.com/en-us/library/ee796272(v=cs.20).aspx)

  1. Events.ISO-code-for-your-translation.resx
  2. Messages.ISO-code-for-your-translation.resx
  3. Scopes.ISO-code-for-your-translation.resx

 * Run the tests and fix any errors so they are green!
 * Rebase off upstream if behind, and submit the Pull Request

## Dependencies

 * Thinktecture.IdentityServer3 - http://www.nuget.org/packages/Thinktecture.IdentityServer3/
