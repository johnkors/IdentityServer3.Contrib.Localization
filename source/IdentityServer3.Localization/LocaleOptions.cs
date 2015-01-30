namespace Thinktecture.IdentityServer.Core.Services.Contrib
{
    public class LocaleOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public string Locale { get; set; }

        public LocaleOptions()
        {
            Locale = Constants.Default;
        }
    }
}