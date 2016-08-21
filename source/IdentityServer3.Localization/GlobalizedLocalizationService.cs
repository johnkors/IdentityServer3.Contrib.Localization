using System;
using IdentityServer3.Core.Services.Contrib.Internals;

namespace IdentityServer3.Core.Services.Contrib
{
    public class GlobalizedLocalizationService : ILocalizationService
    {
        private readonly OwinEnvironmentService _owinEnvironmentService;
        private readonly LocaleOptions _internalOpts;

        public GlobalizedLocalizationService(OwinEnvironmentService owinEnvironmentService, LocaleOptions options = null)
        {
            _owinEnvironmentService = owinEnvironmentService;
            if (owinEnvironmentService == null)
            {
                throw new ArgumentException(@"Cannot be null. Is needed for LocaleProvider Func API. Did you register this service correctly?", "owinEnvironmentService");
            }

            _internalOpts = options ?? new LocaleOptions();
            _owinEnvironmentService = owinEnvironmentService;
        }

        public string GetString(string category, string id)
        {
            var service = LocalizationServiceFactory.Create(_internalOpts, _owinEnvironmentService.Environment);
            return service.GetString(category, id);
        }
    }
}
