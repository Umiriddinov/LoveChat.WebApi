using LoveChat.DataAccess.Utils;
using LoveChat.Domain.Entities.Messages;
using LoveChat.Service.Dtos.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveChat.Service.Interfaces.Messages;

public interface IMessagesService
{
    public Task<bool> CreateAsync(MessageCreateDto dto);

    public Task<bool> DeleteAsync(long categoryId);

    public Task<long> CountAsync();

    public Task<IList<Message>> GetAllAsync(PaginationParams @params);

    public Task<Message> GetByIdAsync(long categoryId);

    public Task<bool> UpdateAsync(long categoryId, MessageUpdateDto dto);
}
