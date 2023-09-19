using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveChat.Service.Interfaces.Auth;

public interface IIdentityService
{

    public string UserName { get; }

    public string PhoneNumber { get; }

}
