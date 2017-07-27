using System;
namespace Started_App.Library.API
{
    public class IdnSDK
    {
        public IdnSDK(ApiContext apiContext)
        {
            AbstractApiContext.registerApiContext(apiContext);
        }
    }
}
