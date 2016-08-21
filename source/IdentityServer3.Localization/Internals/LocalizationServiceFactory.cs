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

            CultureInfo cultureInfo;
            try
            {
                cultureInfo = new CultureInfo(locale);
            }
            catch (CultureNotFoundException)
            {
                cultureInfo = new CultureInfo(Constants.enUS);
            }

            var inner = new ResourceFileLocalizationService(cultureInfo);

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
