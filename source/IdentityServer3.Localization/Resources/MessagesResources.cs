using System.Globalization;
using System.Resources;

namespace Thinktecture.IdentityServer.Core.Services.Contrib.Resources
{
    public class MessagesResources
    {
        private static ResourceManager _resourceManager;

        public static ResourceManager GetResourceManager
        {
            get
            {
                if (_resourceManager == null)
                {
                    _resourceManager = new ResourceManager("Thinktecture.IdentityServer.Core.Services.Contrib.Resources.Messages.Messages", typeof(MessagesResources).Assembly);
                }
                return _resourceManager;

            }
        }
    }
}