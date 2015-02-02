using System.Globalization;
using Thinktecture.IdentityServer.Core.Services.Contrib.Resources;

namespace Thinktecture.IdentityServer.Core.Services.Contrib.Internals
{
    internal class ResourceFileLocalizationService : ILocalizationService
    {
        private readonly CultureInfo _info;

        public ResourceFileLocalizationService(CultureInfo info)
        {
            _info = info;
        }

        public string GetString(string category, string id)
        {
            var lowercasedid = id.ToLower();
            switch (category)
            {
                case "Messages":
                    return MessagesResources.GetResourceManager.GetString(lowercasedid, _info);
                case "Events":
                    return EventResources.ResourceManager.GetString(lowercasedid, _info);
                case "Scopes":
                    return ScopeResources.ResourceManager.GetString(lowercasedid, _info);
                default:
                    return (string) null;
            }
        }
    }
}