using Ecom.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.Domain.Entities
{
    public class User : BaseEntity
    {
        /// <summary>
        /// Name of the user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Unique email of the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Optional phone number, may be collected if really needed.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// We are considering single role will be assigned per user
        /// </summary>
        public UserRole Role { get; set; }

        /// <summary>
        /// User may created from external source. Currently we consider it will be Google
        /// </summary>
        public string ExternalSourceName { get; set; } = "google";

        public string Password { get; set; }
    }
}
