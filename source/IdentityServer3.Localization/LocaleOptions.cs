using System;
using System.Collections.Generic;
using System.Linq;
using IdentityServer3.Core.Logging;

namespace IdentityServer3.Core.Services.Contrib
{
    public class LocaleOptions
    {
        public static readonly ILog Logger = LogProvider.GetCurrentClassLogger();
        /// <summary>
        /// The localization service to be of use when none is found for the given resouce & locale. Default: english.
        /// </summary>
        public ILocalizationService FallbackLocalizationService { get; set; }

        /// <summary>
        /// A function that resolves a given locale. Is executed for each attempt to get a resource.
        /// Should return a Language Culture Name as defined in https://msdn.microsoft.com/en-us/library/ee825488(v=cs.20).aspx
        /// </summary>
        public Func<IDictionary<string, object>, string> LocaleProvider { get; set; }

        internal string GetLocale()
        {
            if (LocaleProvider != null && EnvironmentService != null)
            {
                return LocaleProvider(EnvironmentService.Environment);
            }
            return Constants.Default;
        }

        internal OwinEnvironmentService EnvironmentService { get; set; }


        internal void Validate()
        {
            if (EnvironmentService == null)
            {
                throw new ArgumentException(string.Format("OwinEnvironmentService was null"));
            }
        }
    }
}