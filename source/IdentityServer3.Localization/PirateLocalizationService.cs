using Thinktecture.IdentityServer.Core.Resources;

namespace Thinktecture.IdentityServer.Core.Services.Contrib
{
    internal class PirateLocalizationService : ILocalizationService
    {
        public string GetString(string category, string id)
        {
            var lowerCased = id.ToLower();
            switch (category)
            {
                case Core.Constants.LocalizationCategories.Messages:
                    return PirateMessages.GetString(lowerCased);
                case Core.Constants.LocalizationCategories.Events:
                    return PirateEvents.GetString(lowerCased);
                case Core.Constants.LocalizationCategories.Scopes:
                    return PirateScopes.GetString(lowerCased);
            }
            return null;
        }

        public class PirateMessages
        {
            public static string GetString(string id)
            {
                if (id == MessageIds.ClientIdRequired.ToLower())
                {
                    return "Unknown vessel - arrr you at the right dock?!";
                }
                if (id == MessageIds.ExternalProviderError.ToLower())
                {
                    return "Coming back without treasure?! Be gone with yee!";
                }
                if (id == MessageIds.InvalidUsernameOrPassword.ToLower())
                {
                    return "Yarr! Why are you giving me rubbush credentials, landlubber?!";
                }
                if (id == MessageIds.Invalid_scope.ToLower())
                {
                    return "Always asking for the unobtainable. Walk the plank!";
                }
                if (id == MessageIds.MissingClientId.ToLower())
                {
                    return "Yerr ship is not marked and shall not pass!";
                }
                if (id == MessageIds.MissingToken.ToLower())
                {
                    return "Thy arms are not tatooed?! Come back with the right kind of ink!";
                }
                if (id == MessageIds.MustSelectAtLeastOnePermission.ToLower())
                {
                    return "Pardon my parley, but seems you don't like to give away secrets so easily. Well then. Draw your sword!";
                }
                if (id == MessageIds.NoExternalProvider.ToLower())
                {
                    return "We tend only to our own ship around these parts. Go elsewhere!";
                }
                if (id == MessageIds.NoMatchingExternalAccount.ToLower())
                {
                    return "The rumor is you are the ghost of the seven seas! Go away!";
                }
                if (id == MessageIds.NoSignInCookie.ToLower())
                {
                    return "You scrubbed the deck too many times there, shipmate!";
                }
                if (id == MessageIds.NoSubjectFromExternalProvider.ToLower())
                {
                    return "Nobody knows thy written name! Are you cursed?!";
                }
                if (id == MessageIds.PasswordRequired.ToLower())
                {
                    return "Not coming aboard without a passphrase. If it's seagull123, I'll throw you overboard! ";
                }
                if (id == MessageIds.SslRequired.ToLower())
                {
                    return "Yarr! Not following protocols is DANGEROUS around these parts. Yee be warned.. And banished. Very banished.";
                }
                if (id == MessageIds.SslRequired.ToLower())
                {
                    return "Yarr! Not following protocols is DANGEROUS around these parts. Yee be warned.. And banished. Very banished.";
                }
                if (id == MessageIds.Unauthorized_client.ToLower())
                {
                    return "This ship has not thrown it's anchor around these waters for a long time!";
                }
                if (id == MessageIds.UnexpectedError.ToLower())
                {
                    return "Man over board!!! Check the ships log!";
                }
                if (id == MessageIds.UnsupportedMediaType.ToLower())
                {
                    return "Asking for grog? You have to earn it first!";
                }
                if (id == MessageIds.Unsupported_response_type.ToLower())
                {
                    return "Polly wants a what?";
                }
                if (id == MessageIds.UsernameRequired.ToLower())
                {
                    return "Give me yerr name, sailor!";
                }

                return null;
            }
        }
    }

    public class PirateScopes
    {
        public static string GetString(string id)
        {
            if (id == ScopeIds.Address_DisplayName.ToLower())
            {
                return "Bunk";
            }
            if (id == ScopeIds.All_claims_DisplayName.ToLower())
            {
                return "EVERYTHING IN YOUR SHALLOW POCKETS";
            }
            if (id == ScopeIds.Email_DisplayName.ToLower())
            {
                return "Pidgeon";
            }
            if (id == ScopeIds.Offline_access_DisplayName.ToLower())
            {
                return "Do stuff while you sleep";
            }
            if (id == ScopeIds.Openid_DisplayName.ToLower())
            {
                return "Birthmark";
            }
            if (id == ScopeIds.Phone_DisplayName.ToLower())
            {
                return "Other pidgeon";
            }
            if (id == ScopeIds.Profile_Description.ToLower())
            {
                return "Background as a sailor";
            }
            if (id == ScopeIds.Profile_DisplayName.ToLower())
            {
                return "Sailing experience";
            }
            if (id == ScopeIds.Roles_DisplayName.ToLower())
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
            if (id == EventIds.ExternalLoginFailure.ToLower())
            {
                return "Boarding other ship IMPOSSIBLE. Everyone drowned!";
            }
            if (id == EventIds.ExternalLoginSuccess.ToLower())
            {
                return "Other ship boarded as planned. Lovely treasure!";
            }
            if (id == EventIds.LocalLoginFailure.ToLower())
            {
                return "Uknown sailor";
            }
            if (id == EventIds.LocalLoginSuccess.ToLower())
            {
                return "Welcome aboard!";
            }
            if (id == EventIds.LogoutEvent.ToLower())
            {
                return "Nice sailing with you";
            }
            if (id == EventIds.PartialLogin.ToLower())
            {
                return "Asking around about yee";
            }
            if (id == EventIds.PartialLoginComplete.ToLower())
            {
                return "Yarr, thy background checks out";
            }
            if (id == EventIds.PreLoginFailure.ToLower())
            {
                return "Halt! You're not even allowed on the docks!";
            }
            if (id == EventIds.PreLoginSuccess.ToLower())
            {
                return "Brought the grog, ey. Okay. Go on.";
            }
            return null;
        }
    }
}