using System;
using System.Collections.Generic;
using System.Globalization;
using Thinktecture.IdentityServer.Core.Resources;
using Thinktecture.IdentityServer.Core.Services.Default;

namespace Thinktecture.IdentityServer.Core.Services.Contrib
{
    public static class LocalizationServiceFactory
    {
        private const string Default = "Default";

        private static readonly IDictionary<string, Func<CultureInfo,ILocalizationService>> AvailableLocalizationServices = new Dictionary<string, Func<CultureInfo,ILocalizationService>>
        {
            { Default, lang => new DefaultLocalizationService() },
            { "nb-NO", lang => new ResourceFileLocalizationService(lang)}
        };

        public static ILocalizationService Create(LocaleOptions options = null)
        {
            var internalOpts = options ?? new LocaleOptions();
            var choice = string.IsNullOrEmpty(internalOpts.Locale) ? Default : internalOpts.Locale;
            var culture = new CultureInfo(internalOpts.Locale);
            Func<CultureInfo, ILocalizationService> serviceBuilder;
            var isAvailable = AvailableLocalizationServices.TryGetValue(choice, out serviceBuilder);
            if (!isAvailable)
            {
                throw new ApplicationException(string.Format("Localization '{0}' unavailable. Create a Pull Request on GitHub!", options.Locale));
            }
          
            return serviceBuilder(culture);
        }
    }
}