using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveChat.Service.Dtos.Users;

public class UserCreateDto
{
    public string UserName { get; set; } = String.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

}
