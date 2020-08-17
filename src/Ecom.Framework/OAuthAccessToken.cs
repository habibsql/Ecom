using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.Framework
{
    // break the convension but no json serialization attribute assignment needed
    public  class OAuthAccessToken
    {
        public int expires_in { get; set; }


        public string token_type { get; set; }

        public string access_token { get; set; }

    }
}
