using System.Resources;

namespace IdentityServer3.Core.Services.Contrib.Resources
{
    public class ScopeResources
    {
        private static ResourceManager _resourceManager;

        public static ResourceManager ResourceManager
        {
            get
            {
                if (_resourceManager == null)
                {
                    _resourceManager = new ResourceManager("Thinktecture.IdentityServer.Core.Services.Contrib.Resources.Scopes.Scopes", typeof(ScopeResources).Assembly);
                }
                return _resourceManager;

            }
        }
    }
}