using System;
using System.Collections.Generic;
using System.Linq;
using IdentityServer3.Core.Services;
using Thinktecture.IdentityServer.Core.Services.Contrib.Internals;

namespace Thinktecture.IdentityServer.Core.Services.Contrib
{
    public class GlobalizedLocalizationService : ILocalizationService
    {
        private readonly ILocalizationService _service;

        public GlobalizedLocalizationService(LocaleOptions options = null)
        {
            var internalOpts = options ?? new LocaleOptions();
            Validate(internalOpts);
            _service = LocalizationServiceFactory.Create(internalOpts);
        }

        private void Validate(LocaleOptions options)
        {
            if (options.Locale == null || options.Locale.Trim() == string.Empty || !GetAvailableLocales().Contains(options.Locale))
            {
                throw new ApplicationException(string.Format("Localization '{0}' unavailable. Create a Pull Request on GitHub!", options.Locale));
            }
        }

        public string GetString(string category, string id)
        {
            return _service.GetString(category, id);
        }

        public static IEnumerable<string> GetAvailableLocales()
        {
            return LocalizationServiceFactory.AvailableLocalizationServices.Keys;
        }
    }
}
