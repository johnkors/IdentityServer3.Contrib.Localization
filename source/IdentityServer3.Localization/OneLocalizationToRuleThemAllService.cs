using System.Globalization;
using Thinktecture.IdentityServer.Core.Services.Contrib.Resources;

namespace Thinktecture.IdentityServer.Core.Services.Contrib
{
    public class OneLocalizationToRuleThemAllService : ILocalizationService
    {
        private readonly CultureInfo _info;

        public OneLocalizationToRuleThemAllService(CultureInfo info)
        {
            _info = info;
        }

        public string GetString(string category, string id)
        {
            switch (category)
            {
                case "Messages":
                    return MessagesResources.GetResourceManager.GetString(id, _info);
                case "Events":
                    return EventResources.ResourceManager.GetString(id, _info);
                case "Scopes":
                    return ScopeResources.ResourceManager.GetString(id, _info);
                default:
                    return (string) null;
            }
        }
    }
}