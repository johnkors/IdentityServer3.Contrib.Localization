using IdentityServer3.Core.Services.Contrib.Resources;
using System.Globalization;

namespace IdentityServer3.Core.Services.Contrib.Internals
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