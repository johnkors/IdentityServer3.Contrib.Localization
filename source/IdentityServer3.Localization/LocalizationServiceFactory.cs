using System;
using System.Collections.Generic;
using System.Globalization;
using Thinktecture.IdentityServer.Core.Services.Default;

namespace Thinktecture.IdentityServer.Core.Services.Contrib
{
    internal static class LocalizationServiceFactory
    {
        public static readonly IDictionary<string, ILocalizationService> AvailableLocalizationServices;

        static LocalizationServiceFactory()
        {
            AvailableLocalizationServices = new Dictionary<string, ILocalizationService>
            {
                {Constants.Default, new DefaultLocalizationService()},
                {Constants.Pirate, new PirateLocalizationService()}
            };
            AvailableLocalizationServices.Add(CreateResourceBased(Constants.nbNO));
            AvailableLocalizationServices.Add(CreateResourceBased(Constants.trTR));
        }

        public static ILocalizationService Create(LocaleOptions options)
        {
            var inner = AvailableLocalizationServices[options.Locale];
            if (options.FallbackLocalizationService != null)
            {
                return new FallbackDecorator(inner, options.FallbackLocalizationService);
            }
            return new FallbackDecorator(inner, AvailableLocalizationServices[Constants.Default]);
        }

        private static KeyValuePair<string, ILocalizationService> CreateResourceBased(string locale)
        {
            return new KeyValuePair<string, ILocalizationService>(locale, new ResourceFileLocalizationService(new CultureInfo(locale)));
        } 
    }
}
