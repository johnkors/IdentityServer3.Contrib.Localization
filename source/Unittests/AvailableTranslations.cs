using System.Collections.Generic;
using IdentityServer3.Core.Resources;
using IdentityServer3.Core.Services;
using IdentityServer3.Core.Services.Contrib;
using Xunit;
using Constants = IdentityServer3.Core.Constants;

namespace Unittests
{
    public class AvailableTranslations
    {
        [Theory]
        [InlineData("ar-SA")]
        [InlineData("cs-CZ")]
        [InlineData("de-DE")]
        [InlineData("da-DK")]
        [InlineData("es-AR")]
        [InlineData("es-ES")]
        [InlineData("fi-FI")]
        [InlineData("fr-FR")]
        [InlineData("it-IT")]
        [InlineData("nb")]
        [InlineData("nb-NO")]
        [InlineData("nl-NL")]
        [InlineData("pl-PL")]
        [InlineData("pt-BR")]
        [InlineData("ro-RO")]
        [InlineData("ru-RU")]
        [InlineData("sk-SK")]
        [InlineData("sv-SE")]
        [InlineData("tr-TR")]
        [InlineData("zh-CN")]
        public void ContainsLocales(string locale)
        {
            var env = new Dictionary<string, object>();
            var options = new LocaleOptions
            {
                LocaleProvider = e => locale
            };
            var global = new GlobalizedLocalizationService(new OwinEnvironmentService(env), options);
            var resource = global.GetString(Constants.LocalizationCategories.Messages, MessageIds.MissingClientId);

            Assert.NotEqual("client_id is missing", resource);
        }

        [Theory]
        [InlineData("en-GB")]
        [InlineData("en-US")]
        public void EnglishOnesAsPrDefault(string locale)
        {
            var env = new Dictionary<string, object>();
            var options = new LocaleOptions
            {
                LocaleProvider = e => locale
            };
            var global = new GlobalizedLocalizationService(new OwinEnvironmentService(env), options);
            var resource = global.GetString(Constants.LocalizationCategories.Messages, MessageIds.MissingClientId);

            Assert.Equal("client_id is missing", resource);
        }
    }
}