using IdentityServer3.Core.Services.Default;
using System.Collections.Generic;
using System.Globalization;

namespace IdentityServer3.Core.Services.Contrib.Internals
{
    internal static class LocalizationServiceFactory
    {
        public static ILocalizationService Create(LocaleOptions options)
        {
            var locale = options.GetLocale();

            var inner = new ResourceFileLocalizationService(new CultureInfo(locale));

            if (options.FallbackLocalizationService != null)
            {
                return new FallbackDecorator(inner, options.FallbackLocalizationService);
            }
            return new FallbackDecorator(inner, new DefaultLocalizationService());
        }

        private static KeyValuePair<string, ILocalizationService> CreateResourceBased(string locale)
        {
            return new KeyValuePair<string, ILocalizationService>(locale, new ResourceFileLocalizationService(new CultureInfo(locale)));
        } 
    }
}
