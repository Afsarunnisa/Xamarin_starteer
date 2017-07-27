using System;

using Started_App.Library.Modules.IDS;


namespace Started_App.Library.Modules.Identity
{
    public class IdentityIdsRegistry
    {
        public IdentityIdsRegistry()
        {
            IDS.IDS.register("identity", typeof(IdentityApi));

		}
    }
}
