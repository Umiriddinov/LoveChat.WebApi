using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveChat.Domain.Exceptions.Messages;

public class MessageNotFoundException : NotFoundException
{
    public MessageNotFoundException()
    {
        this.TitleMessage = "Message not found!";

    }
}
