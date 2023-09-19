using LoveChat.Service.Dtos.Notification;

namespace LoveChat.Service.Interfaces.Notification;

public interface ISmsSender
{
    public Task<bool> SendAsync(SmsMessages smsMessage);

}
