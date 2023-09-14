using LoveChat.DataAccess.Common.Interfaces;
using LoveChat.Domain.Entities.Messages;

namespace LoveChat.DataAccess.Interfaces.Messages;

public interface IMessagesRepository : IRepository<Message, Message>,
    IGetAll<Message>, ISearchable<Message>
{
}
