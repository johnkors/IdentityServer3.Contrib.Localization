using System.Linq;
using Thinktecture.IdentityServer.Core.Services.Contrib;
using Xunit;

namespace Unittests
{
    public class AvailableTranslations
    {
        [Theory]
        [InlineData("Default")]
        [InlineData("pirate")]
        [InlineData("nb-NO")]
        [InlineData("tr-TR")]
        [InlineData("de-DE")]
        [InlineData("sv-SE")]
        [InlineData("es-AR")]
        public void ContainsLocales(string locale)
        {
            Assert.Contains(GlobalizedLocalizationService.GetAvailableLocales(), s => s.Equals(locale));
        }

        [Fact]
        public void HasCorrectCount()
        {
            Assert.Equal(7, GlobalizedLocalizationService.GetAvailableLocales().Count());
        }
    }
}