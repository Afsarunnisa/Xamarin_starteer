using System;

using Started_App.Library.Modules.IDS;


namespace Started_App.Library.Modules.Token
{
    public class TokenIdsRegistry
    {
        public TokenIdsRegistry()
        {
            IDS.IDS.register("token", typeof(TokenApi));
        }
    }
}
