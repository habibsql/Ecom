using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.Framework
{
    public class LoggedInContext
    {
        public string UserId { get; }
        
        public string UserName { get; }

        public string UserEmail { get; }

        public string UserRole { get; set; }

        public LoggedInContext(string userId, string userName, string email, string role)
        {
            this.UserId = userId;
            this.UserEmail = UserEmail;
            this.UserRole = role;
            this.UserName = userName;
        }
    }
}
