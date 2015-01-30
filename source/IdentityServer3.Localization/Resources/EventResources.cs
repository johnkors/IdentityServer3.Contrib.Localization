using System.Resources;

namespace Thinktecture.IdentityServer.Core.Services.Contrib.Resources
{
    public class EventResources
    {
        private static ResourceManager _resourceManager;

        public static ResourceManager ResourceManager
        {
            get
            {
                if (_resourceManager == null)
                {
                    _resourceManager = new ResourceManager("Thinktecture.IdentityServer.Core.Services.Contrib.Resources.Events", typeof(EventResources).Assembly);
                }
                return _resourceManager;

            }
        }
    }
}