using FluentValidation;
using LoveChat.Service.Common.Helpers;
using LoveChat.Service.Dtos.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveChat.Service.Validators.Dtos.Messages;

public class MessageUpdateValidator : AbstractValidator<MessageUpdateDto>
{
    public MessageUpdateValidator()
    {

        RuleFor(dto => dto.MessagesText).NotNull().NotEmpty().WithMessage("Description field is required!")
            .MinimumLength(20).WithMessage("Description field is required!");


    }
}
