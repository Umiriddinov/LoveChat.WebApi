using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveChat.Service.Interfaces.Common;

public interface IShortStorageService
{
    public IDictionary<string, string> KeyValuePairs { get; set; }

}
