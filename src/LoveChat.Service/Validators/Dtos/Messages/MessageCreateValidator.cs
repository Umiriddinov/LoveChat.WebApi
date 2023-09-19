using FluentValidation;
using LoveChat.Service.Common.Helpers;
using LoveChat.Service.Dtos.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveChat.Service.Validators.Dtos.Messages;

public class MessageCreateValidator : AbstractValidator<MessageCreateDto>
{
    public MessageCreateValidator()
    {
        RuleFor(dto => dto.UserName).NotNull().NotEmpty().WithMessage("Name field is required!")
        .MinimumLength(3).WithMessage("Name must be more than 3 characters")
        .MaximumLength(50).WithMessage("Name must be less than 50 characters");

        RuleFor(dto => dto.MessagesText).NotNull().NotEmpty().WithMessage("Description field is required!")
            .MinimumLength(20).WithMessage("Description field is required!");

        int maxImageSizeMB = 3;
        RuleFor(dto => dto.Image).NotEmpty().NotNull().WithMessage("Image field is required");
        RuleFor(dto => dto.Image.Length).LessThan(maxImageSizeMB * 1024 * 1024 + 1).WithMessage($"Image size must be less than {maxImageSizeMB} MB");
        RuleFor(dto => dto.Image.FileName).Must(predicate =>
        {
            FileInfo fileInfo = new FileInfo(predicate);
            return MediaHelper.GetImageExtensions().Contains(fileInfo.Extension);
        }).WithMessage("This file type is not image file");
    }
}
