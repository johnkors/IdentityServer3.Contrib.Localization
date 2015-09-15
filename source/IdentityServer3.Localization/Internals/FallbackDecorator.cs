using IdentityServer3.Core.Services;
using IdentityServer3.Core.Services.Default;

namespace Thinktecture.IdentityServer.Core.Services.Contrib.Internals
{
    internal class FallbackDecorator : ILocalizationService
    {
        private readonly ILocalizationService _inner;
        private readonly ILocalizationService _fallBackService;

        public FallbackDecorator(ILocalizationService inner, ILocalizationService fallBackService)
        {
            _inner = inner;
            _fallBackService = fallBackService ?? new DefaultLocalizationService();
        }

        public string GetString(string category, string id)
        {
            var innerString = _inner.GetString(category, id);
            if (string.IsNullOrEmpty(innerString) && _fallBackService != null)
            {
                return _fallBackService.GetString(category, id);
            }
            return innerString;
        }
    }
}