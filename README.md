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
   var factory = new IdentityServerServiceFactory();
   var options = new LocaleOptions { LocaleProvider = env => "nb-NO" };

   factory.Register(new Registration<LocaleOptions>(options));   
   factory.LocalizationService = new Registration<ILocalizationService, GlobalizedLocalizationService>();
```

- To use IdentityServer3s default provided localization fixed:
```
   var factory = new IdentityServerServiceFactory();
   factory.LocalizationService = new Registration<ILocalizationService, GlobalizedLocalizationService>();
```

- To use Pirate culture:
```
   var factory = new IdentityServerServiceFactory();
   var options = new LocaleOptions { LocaleProvider = env => "pirate" };

   factory.Register(new Registration<LocaleOptions>(options));   
   factory.LocalizationService = new Registration<ILocalizationService, GlobalizedLocalizationService>();

```

- Making use of the users language setting:
```
using System.Net.Http.Headers; // if you want to use StringWithQualityHeaderValue
 

  var opts = new LocaleOptions
  {
      LocaleProvider = env =>
      {
          var owinContext = new OwinContext(env);
          var owinRequest = owinContext.Request;
          var headers = owinRequest.Headers;
          var accept_language_header = headers["accept-language"].ToString();
          var languages = accept_language_header
                              .Split(',')
                              .Select(StringWithQualityHeaderValue.Parse)
                              .OrderByDescending(s => s.Quality.GetValueOrDefault(1));
         var locale = languages.First().Value;
         return locale;
      }
  };
  
  factory.Register(new Registration<LocaleOptions>(opts));
  factory.LocalizationService = new Registration<ILocalizationService, GlobalizedLocalizationService>();

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
