using System.Collections.Generic;
using System.Globalization;
using Thinktecture.IdentityServer.Core.Resources;
using Thinktecture.IdentityServer.Core.Services.Contrib;
using Xunit;

namespace Unittests
{
    public class OneLocalizationToRuleThemAllServiceTests
    {
        private readonly IEnumerable<string> _possibleMessageIds = new List<string>
        {
            MessageIds.ClientIdRequired,
            MessageIds.ExternalProviderError,
            MessageIds.InvalidUsernameOrPassword,
            MessageIds.Invalid_scope,
            MessageIds.MissingClientId,
            MessageIds.MissingToken,
            MessageIds.MustSelectAtLeastOnePermission,
            MessageIds.NoExternalProvider,
            MessageIds.NoMatchingExternalAccount,
            MessageIds.NoSignInCookie,
            MessageIds.NoSubjectFromExternalProvider,
            MessageIds.PasswordRequired,
            MessageIds.SslRequired,
            MessageIds.Unauthorized_client,
            MessageIds.UnexpectedError,
            MessageIds.UnsupportedMediaType,
            MessageIds.Unsupported_response_type,
            MessageIds.UsernameRequired
        };

        [Fact]
        [InlineData("nb-NO")]
        public void ShouldGetLocalizedContents(string culture)
        {
            var info = new CultureInfo(culture);
            var service = new OneLocalizationToRuleThemAllService(info);

            foreach (var possibleMessageId in _possibleMessageIds)
            {
                var localizedString = service.GetString("Messages", possibleMessageId);
                Assert.NotNull(localizedString);
            }
        }

    }
}
