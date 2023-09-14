using LoveChat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveChat.DataAccess.ViewModels
{
    public class UserViewModel : Auditable
    {
        public string FirstName { get; set; } = String.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

    }
}
