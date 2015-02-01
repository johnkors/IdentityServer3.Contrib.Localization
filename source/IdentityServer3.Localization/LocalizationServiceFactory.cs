using System;
using System.Collections.Generic;
using System.Globalization;
using Thinktecture.IdentityServer.Core.Services.Default;

namespace Thinktecture.IdentityServer.Core.Services.Contrib
{
    public static class LocalizationServiceFactory
    {
        public static readonly IDictionary<string, Func<CultureInfo,ILocalizationService>> AvailableLocalizationServices = new Dictionary<string, Func<CultureInfo,ILocalizationService>>
        {
            { Constants.Default, lang => new DefaultLocalizationService() },
            { "nb-NO", lang => new ResourceFileLocalizationService(lang)},
            { "pirate", lang => new PirateLocalizationService()}
        };

        public static ILocalizationService Create(LocaleOptions options = null)
        {
            var internalOpts = options == null || string.IsNullOrEmpty(options.Locale) ? new LocaleOptions() : options;
            if (internalOpts.Locale == Constants.Pirate)
            {
                return AvailableLocalizationServices[Constants.Pirate](null);
            }

            if (internalOpts.Locale == Constants.Default)
            {
                return AvailableLocalizationServices[Constants.Default](null);
            }

            var culture = new CultureInfo(internalOpts.Locale);
            Func<CultureInfo, ILocalizationService> serviceBuilder;
            var isAvailable = AvailableLocalizationServices.TryGetValue(internalOpts.Locale, out serviceBuilder);
            if (!isAvailable)
            {
                throw new ApplicationException(string.Format("Localization '{0}' unavailable. Create a Pull Request on GitHub!", options.Locale));
            }
          
            return serviceBuilder(culture);
        }
    }
}