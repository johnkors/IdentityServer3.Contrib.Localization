using System;
using System.Collections.Generic;
using System.Linq;

namespace IdentityServer3.Core.Services.Contrib
{
    public class LocaleOptions
    {
        /// <summary>
        /// The localization service to be of use when none is found for the given resouce & locale. Default: english.
        /// </summary>
        public ILocalizationService FallbackLocalizationService { get; set; }

        /// <summary>
        /// A function that resolves a given locale. Is executed for each attempt to get a resource.
        /// Should return a Language Culture Name as defined in https://msdn.microsoft.com/en-us/library/ee825488(v=cs.20).aspx
        /// </summary>
        public Func<IDictionary<string, object>, string> LocaleProvider { get; set; }

        internal string GetLocale()
        {
            if (LocaleProvider != null && EnvironmentService != null)
            {
                return LocaleProvider(EnvironmentService.Environment);
            }
            return Constants.Default;
        }

        internal OwinEnvironmentService EnvironmentService { get; set; }


        internal void Validate(IEnumerable<string> availableLocales)
        {
            var locale = GetLocale();
            var providedFixedLocaleDoesNotExist = locale == null || locale.Trim() == string.Empty || !availableLocales.Contains(locale);
            if (providedFixedLocaleDoesNotExist)
            {
                throw new ApplicationException(string.Format("Localization '{0}' unavailable. Create a Pull Request on GitHub!", locale));
            }

            if (string.IsNullOrEmpty(locale) && LocaleProvider != null && EnvironmentService == null)
            {
                throw new ApplicationException(string.Format("When using the LocaleProvider Func API, you need to provide an OwinEnvironmentService. Was null."));
            }
        }
    }
}