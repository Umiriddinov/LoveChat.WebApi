using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveChat.Service.Services.Common;

public class ShortStorageService
{
    public IDictionary<string, string> KeyValuePairs { get; set; }


    public ShortStorageService()
    {
        KeyValuePairs = new Dictionary<string, string>();
    }
}
