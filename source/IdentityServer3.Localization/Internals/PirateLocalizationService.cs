using IdentityServer3.Core.Resources;
using IdentityServer3.Core.Services;

namespace Thinktecture.IdentityServer.Core.Services.Contrib.Internals
{
    internal class PirateLocalizationService : ILocalizationService
    {
        public string GetString(string category, string id)
        {
            var lowerCased = id;
            switch (category)
            {
                case IdentityServer3.Core.Constants.LocalizationCategories.Messages:
                    return PirateMessages.GetString(lowerCased);
                case IdentityServer3.Core.Constants.LocalizationCategories.Events:
                    return PirateEvents.GetString(lowerCased);
                case IdentityServer3.Core.Constants.LocalizationCategories.Scopes:
                    return PirateScopes.GetString(lowerCased);
            }
            return null;
        }

        public class PirateMessages
        {
            public static string GetString(string id)
            {
                if (id == MessageIds.ClientIdRequired)
                {
                    return "Unknown vessel - arrr you at the right dock?!";
                }
                if (id == MessageIds.ExternalProviderError)
                {
                    return "Coming back without treasure?! Be gone with yee!";
                }
                if (id == MessageIds.InvalidUsernameOrPassword)
                {
                    return "Yarr! Why are you giving me rubbush credentials, landlubber?!";
                }
                if (id == MessageIds.Invalid_scope)
                {
                    return "Always asking for the unobtainable. Walk the plank!";
                }
                if (id == MessageIds.MissingClientId)
                {
                    return "Yerr ship is not marked and shall not pass!";
                }
                if (id == MessageIds.MissingToken)
                {
                    return "Thy arms are not tatooed?! Come back with the right kind of ink!";
                }
                if (id == MessageIds.MustSelectAtLeastOnePermission)
                {
                    return "Pardon my parley, but seems you don't like to give away secrets so easily. Well then. Draw your sword!";
                }
                if (id == MessageIds.NoExternalProvider)
                {
                    return "We tend only to our own ship around these parts. Go elsewhere!";
                }
                if (id == MessageIds.NoMatchingExternalAccount)
                {
                    return "The rumor is you are the ghost of the seven seas! Go away!";
                }
                if (id == MessageIds.NoSignInCookie)
                {
                    return "You scrubbed the deck too many times there, shipmate!";
                }
                if (id == MessageIds.NoSubjectFromExternalProvider)
                {
                    return "Nobody knows thy written name! Are you cursed?!";
                }
                if (id == MessageIds.PasswordRequired)
                {
                    return "Not coming aboard without a passphrase. If it's seagull123, I'll throw you overboard! ";
                }
                if (id == MessageIds.SslRequired)
                {
                    return "Yarr! Not following protocols is DANGEROUS around these parts. Yee be warned.. And banished. Very banished.";
                }
                if (id == MessageIds.SslRequired)
                {
                    return "Yarr! Not following protocols is DANGEROUS around these parts. Yee be warned.. And banished. Very banished.";
                }
                if (id == MessageIds.Unauthorized_client)
                {
                    return "This ship has not thrown it's anchor around these waters for a long time!";
                }
                if (id == MessageIds.UnexpectedError)
                {
                    return "Man over board!!! Check the ships log!";
                }
                if (id == MessageIds.UnsupportedMediaType)
                {
                    return "Asking for grog? You have to earn it first!";
                }
                if (id == MessageIds.Unsupported_response_type)
                {
                    return "Polly wants a what?";
                }
                if (id == MessageIds.UsernameRequired)
                {
                    return "Give me yerr name, sailor!";
                }
                if (id == MessageIds.Invalid_request)
                {
                    return "Shiver me timbers, where did that request come from?!";
                }

                return null;
            }
        }
    }

    public class PirateScopes
    {
        public static string GetString(string id)
        {
            if (id == ScopeIds.Address_DisplayName)
            {
                return "Bunk";
            }
            if (id == ScopeIds.All_claims_DisplayName)
            {
                return "EVERYTHING IN YOUR SHALLOW POCKETS";
            }
            if (id == ScopeIds.Email_DisplayName)
            {
                return "Pidgeon";
            }
            if (id == ScopeIds.Offline_access_DisplayName)
            {
                return "Do stuff while you sleep";
            }
            if (id == ScopeIds.Openid_DisplayName)
            {
                return "Birthmark";
            }
            if (id == ScopeIds.Phone_DisplayName)
            {
                return "Other pidgeon";
            }
            if (id == ScopeIds.Profile_Description)
            {
                return "Background as a sailor";
            }
            if (id == ScopeIds.Profile_DisplayName)
            {
                return "Sailing experience";
            }
            if (id == ScopeIds.Roles_DisplayName)
            {
                return "Crews";
            }

            return null;
        }
    }

    public class PirateEvents
    {
        public static string GetString(string id)
        {
            if (id == EventIds.ExternalLoginFailure)
            {
                return "Boarding other ship IMPOSSIBLE. Everyone drowned!";
            }
            if (id == EventIds.ExternalLoginSuccess)
            {
                return "Other ship boarded as planned. Lovely treasure!";
            }
            if (id == EventIds.LocalLoginFailure)
            {
                return "Uknown sailor";
            }
            if (id == EventIds.LocalLoginSuccess)
            {
                return "Welcome aboard!";
            }
            if (id == EventIds.LogoutEvent)
            {
                return "Nice sailing with you";
            }
            if (id == EventIds.PartialLogin)
            {
                return "Asking around about yee";
            }
            if (id == EventIds.PartialLoginComplete)
            {
                return "Yarr, thy background checks out";
            }
            if (id == EventIds.PreLoginFailure)
            {
                return "Halt! You're not even allowed on the docks!";
            }
            if (id == EventIds.PreLoginSuccess)
            {
                return "Brought the grog, ey. Okay. Go on.";
            }
            if (id == EventIds.ClientPermissionsRevoked)
            {
                return "a";
            }
            if (id == EventIds.CspReport)
            {
                return "b";
            }
            if (id == EventIds.ResourceOwnerFlowLoginFailure)
            {
                return "c";
            }
            if (id == EventIds.ResourceOwnerFlowLoginSuccess)
            {
                return "d";
            }
            if (id == EventIds.ExternalLoginError)
            {
                return "b";
            }
            return null;
        }
    }
}