using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.Framework
{
    public class OAuthInfo
    {
        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string RedirectUrl { get; set; }

        public string GrantType { get; set; }
    }
}
