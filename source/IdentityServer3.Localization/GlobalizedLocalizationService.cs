using System.Collections.Generic;

namespace Thinktecture.IdentityServer.Core.Services.Contrib
{
    public class GlobalizedLocalizationService : ILocalizationService
    {
        private readonly ILocalizationService _service;

        public GlobalizedLocalizationService(LocaleOptions options = null)
        {
            _service = LocalizationServiceFactory.Create(options);
        }

        public string GetString(string category, string id)
        {
            return _service.GetString(category, id);
        }

        public IEnumerable<string> GetAvailableLocales()
        {
            return LocalizationServiceFactory.AvailableLocalizationServices.Keys;
        }
    }
}
