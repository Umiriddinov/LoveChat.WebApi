using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveChat.Service.Dtos.Messages;

public class MessageCreateDto
{
    public string UserName { get; set; } = String.Empty;

    public string PhoneNumber { get; set; } = String.Empty;

    public string MessagesText { get; set; } = string.Empty;

    public IFormFile Image { get; set; } = default!;


}
