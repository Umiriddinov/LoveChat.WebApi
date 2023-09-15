using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveChat.Service.Dtos.Messages;

public class MessageCreateDto
{
    public string Name { get; set; } = String.Empty;

    public string PhoneNumber { get; set; } = String.Empty;

    public IFormFile Image { get; set; } = default!;

}
