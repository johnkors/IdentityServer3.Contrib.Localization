namespace Thinktecture.IdentityServer.Core.Services.Contrib
{
    public class LocaleOptions
    {
        /// <summary>
        /// The Language Culture Name as defined in https://msdn.microsoft.com/en-us/library/ee825488(v=cs.20).aspx
        /// </summary>
        /// <list type="SupportedValues">
        /// "nb-NO"
        /// </list>
        public string Locale { get; set; }
        public ILocalizationService FallbackLocalizationService { get; set; }

        public LocaleOptions()
        {
            Locale = Constants.Default;
        }
    }
}