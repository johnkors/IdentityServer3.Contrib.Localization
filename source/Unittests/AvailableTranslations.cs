using System.Linq;
using IdentityServer3.Core.Services.Contrib;
using Xunit;

namespace Unittests
{
    public class AvailableTranslations
    {
        [Theory]
        [InlineData("Default")]
        [InlineData("pirate")]
        [InlineData("ar-SA")]
        [InlineData("cs-CZ")]
        [InlineData("de-DE")]
        [InlineData("da-DK")]
        [InlineData("en-GB")]
        [InlineData("en-US")]
        [InlineData("es-AR")]
        [InlineData("es-ES")]
        [InlineData("fi-FI")]
        [InlineData("fr-FR")]
        [InlineData("it-IT")]
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
            Assert.Contains(GlobalizedLocalizationService.GetAvailableLocales(), s => s.Equals(locale));
        }

        [Fact]
        public void HasCorrectCount()
        {
            Assert.Equal(23, GlobalizedLocalizationService.GetAvailableLocales().Count());
        }
    }
}