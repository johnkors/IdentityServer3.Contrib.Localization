using System;
using IdentityServer3.Core.Services.Contrib.Internals;
using System.Collections.Generic;

namespace IdentityServer3.Core.Services.Contrib
{
    public class GlobalizedLocalizationService : ILocalizationService
    {
        private readonly LocaleOptions _internalOpts;

        public GlobalizedLocalizationService(OwinEnvironmentService owinEnvironmentService, LocaleOptions options = null)
        {
            if (owinEnvironmentService == null)
            {
                throw new ArgumentException(@"Cannot be null. Is needed for LocaleProvider Func API. Did you register this service correctly?", "owinEnvironmentService");
            }

            _internalOpts = options ?? new LocaleOptions();
            _internalOpts.EnvironmentService = owinEnvironmentService;
        }

        public string GetString(string category, string id)
        {
            var service = LocalizationServiceFactory.Create(_internalOpts);
            return service.GetString(category, id);
        }

        public static IEnumerable<string> GetAvailableLocales()
        {
            return LocalizationServiceFactory.AvailableLocalizationServices.Keys;
        }
    }
}
