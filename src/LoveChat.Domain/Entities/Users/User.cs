using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveChat.Domain.Entities.Users
{
    public class User : Auditable
    {
        public string UserName { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = String.Empty;

        public string Salt { get; set; } = String.Empty;

        public string PhoneNumber { get; set; } = String.Empty;

    }
}
