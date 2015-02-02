using Thinktecture.IdentityServer.Core.Services.Default;

namespace Thinktecture.IdentityServer.Core.Services.Contrib
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

        public ILocalizationService FallBackService
        {
            get { return _fallBackService; }
        }


        public string GetString(string category, string id)
        {
            var innerString = _inner.GetString(category, id);
            if (string.IsNullOrEmpty(innerString) && FallBackService != null)
            {
                return FallBackService.GetString(category, id);
            }
            return innerString;
        }
    }
}