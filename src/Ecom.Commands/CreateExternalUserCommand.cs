using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.Framework
{
    /// <summary>
    /// Google Account information
    /// </summary>
    public class CreateExternalUserCommand
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string ExternalUserId { get; set; }

        public string PhoneNumber { get; set; }
    }
}
