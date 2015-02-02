using System;
using System.Collections.Generic;
using System.Linq;
using Thinktecture.IdentityServer.Core.Resources;
using Thinktecture.IdentityServer.Core.Services.Contrib;
using Xunit;
using Xunit.Sdk;
using IdSrvConstants = Thinktecture.IdentityServer.Core.Constants;

namespace Unittests
{
    public class Translate
    {
        [Theory]
        [InlineData("pirate")]
        [InlineData("nb-NO")]
        [InlineData("tr-TR")]
        public void ShouldGetLocalizedMessages(string culture)
        {
            AssertTranslationExists(culture, TestHelper.GetAllMessageIds(), IdSrvConstants.LocalizationCategories.Messages);
            AssertTranslationExists(culture, TestHelper.GetAllEventIds(), IdSrvConstants.LocalizationCategories.Events);
            AssertTranslationExists(culture, TestHelper.GetAllScopeIds(), IdSrvConstants.LocalizationCategories.Scopes);
        }

        /// <summary>
        /// Bug / invariance in idsrv ids sent to ILocalizationService. Handle it here.
        /// </summary>
        /// <param name="culture"></param>
        [Theory]
        [InlineData("pirate")]
        [InlineData("nb-NO")]
        [InlineData("tr-TR")]
        public void ShouldGetLocalizedMessagesRegardlessOfCasing(string culture)
        {
            var messageidsUppercased = TestHelper.GetAllMessageIds().Select(mid => mid.ToUpper());
            var eventidsUppercased = TestHelper.GetAllEventIds().Select(mid => mid.ToUpper());
            var scopeidsUppercased = TestHelper.GetAllScopeIds().Select(mid => mid.ToUpper());
            AssertTranslationExists(culture, messageidsUppercased, IdSrvConstants.LocalizationCategories.Messages);
            AssertTranslationExists(culture, eventidsUppercased, IdSrvConstants.LocalizationCategories.Events);
            AssertTranslationExists(culture, scopeidsUppercased, IdSrvConstants.LocalizationCategories.Scopes);
        }
        
        [Theory(Skip = "Bug in idsrv default localization service. Enable when fixed")]
        [InlineData("")] // <-- This means using IdentityServers DefaultLocalizationService
        [InlineData("Default")] // <-- This means using IdentityServers DefaultLocalizationService
        public void ShouldGetIdServersLocalizedMessages(string culture)
        {
            AssertTranslationExists(culture, TestHelper.GetAllMessageIds(), IdSrvConstants.LocalizationCategories.Messages);
            AssertTranslationExists(culture, TestHelper.GetAllEventIds(), IdSrvConstants.LocalizationCategories.Events);
            AssertTranslationExists(culture, TestHelper.GetAllScopeIds(), IdSrvConstants.LocalizationCategories.Scopes);
        }

        [Fact(Skip = "Bug in idsrv default localization service.Enable when fixed")]
        public void ShouldUseDefaultLocalizationServiceForNull()
        {
            AssertTranslationExists(null, TestHelper.GetAllMessageIds(), IdSrvConstants.LocalizationCategories.Messages);
            AssertTranslationExists(null, TestHelper.GetAllEventIds(), IdSrvConstants.LocalizationCategories.Events);
            AssertTranslationExists(null, TestHelper.GetAllScopeIds(), IdSrvConstants.LocalizationCategories.Scopes);
        }

        [Fact]
        public void ShouldThrowExceptionForNotFoundLocale()
        {
            var options = new LocaleOptions
            {
                Locale = "notexisting"
            };
            Assert.Throws<ApplicationException>(() => new GlobalizedLocalizationService(options));
        }

        [Theory]
        [InlineData("Default")]
        [InlineData("pirate")]
        [InlineData("nb-NO")]
        [InlineData("tr-TR")]
        public void AvailableLocalesContainsTranslations(string locale)
        {
            var localeService = new GlobalizedLocalizationService();
            var availableLocales = localeService.GetAvailableLocales();
            Assert.Contains(availableLocales, s => s.Equals(locale));
        }

        [Fact]
        public void ShouldHaveCorrectCount()
        {
            var localeService = new GlobalizedLocalizationService();
            var availableLocales = localeService.GetAvailableLocales();
            Assert.Equal(4, availableLocales.Count());
        }

        private static void AssertTranslationExists(string culture, IEnumerable<string> ids, string category)
        {
            var options = new LocaleOptions
            {
                Locale = culture
            };
            var service = new GlobalizedLocalizationService(options);
            var notFoundTranslations = new List<string>();
            foreach (var scopeId in ids)
            {
                var localizedString = service.GetString(category, scopeId);
                if (string.IsNullOrEmpty(localizedString))
                {
                    var errormsg = string.Format("Could not find translation of Id '{0}' in {1}", scopeId,
                        string.IsNullOrEmpty(culture) ? "IdentityServers internals" : culture);
                    notFoundTranslations.Add(errormsg);

                }
                else
                {
                    Assert.NotEqual("", localizedString.Trim());    
                }
                
            }
            if (notFoundTranslations.Any())
            {
                var concated = notFoundTranslations.Aggregate((x, y) => x + ", " + y);
                throw new AssertActualExpectedException("Some translation", "NOTHING!", concated );
            }
        }
    }

    internal static class TestHelper
    {
        public static IEnumerable<string> GetAllMessageIds()
        {
            return typeof(MessageIds).GetFields().Select( m => m.GetRawConstantValue().ToString());            
        }

        public static IEnumerable<string> GetAllEventIds()
        {
            return typeof(EventIds).GetFields().Select(m => m.GetRawConstantValue().ToString());
        }

        public static IEnumerable<string> GetAllScopeIds()
        {
            return typeof(ScopeIds).GetFields().Select(m => m.GetRawConstantValue().ToString());
        }
    }
}
