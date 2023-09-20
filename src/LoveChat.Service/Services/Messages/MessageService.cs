using LoveChat.DataAccess.Interfaces.Messages;
using LoveChat.DataAccess.Utils;
using LoveChat.Domain.Entities.Messages;
using LoveChat.Domain.Exceptions.File;
using LoveChat.Domain.Exceptions.Messages;
using LoveChat.Service.Common.Helpers;
using LoveChat.Service.Dtos.Messages;
using LoveChat.Service.Interfaces.Common;
using LoveChat.Service.Interfaces.Messages;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveChat.Service.Services.Messages;

public class MessageService : IMessagesService
{
    private readonly IMessagesRepository _repository;
    private readonly IFileService _fileService;
    private readonly IMemoryCache _memoryCache;
    private readonly IPaginator _paginator;


    public MessageService(IMessagesRepository repository, 
        IFileService fileService, 
        IMemoryCache memoryCache, 
        IPaginator paginator)
    {
        this._repository = repository;
        this._fileService = fileService;
        this._memoryCache = memoryCache;
        this._paginator = paginator;
    }

    public async Task<long> CountAsync() => await _repository.CountAsync();

    public async Task<bool> CreateAsync(MessageCreateDto dto)
    {
        string imagepath = await _fileService.UploadImageAsync(dto.Image);

        Message message = new Message()
        {
            ImagePath = imagepath,
            MessagesText = dto.MessagesText,
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt = TimeHelper.GetDateTime()
        };
        var result = await _repository.CreateAsync(message);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(long messageId)
    {
        var message = await _repository.GetByIdAsync(messageId);
        if (message is null) throw new MessageNotFoundException();

        var result = await _fileService.DeleteImageAsync(message.ImagePath);
        if (result == false) throw new ImageNotFoundException();

        var dbResult = await _repository.DeleteAsync(messageId);
        return dbResult > 0;
    }



    public async Task<IList<Message>> GetAllAsync(PaginationParams @params)
    {
        var message = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);
        return message;
    }

    public async Task<Message> GetByIdAsync(long messageId)
    {
        var message = await _repository.GetByIdAsync(messageId);
        if (message is null) throw new MessageNotFoundException();
        return message;
    }

    public async Task<bool> UpdateAsync(long messageId, MessageUpdateDto dto)
    {
        var message = await _repository.GetByIdAsync(messageId);
        if (message is null) throw new MessageNotFoundException();

        // parse new items to category
        message.MessagesText = dto.MessagesText;

        // else category old image have to save

        message.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _repository.UpdateAsync(messageId, message);
        return dbResult > 0;
    }
}
