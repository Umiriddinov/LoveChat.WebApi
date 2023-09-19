using LoveChat.DataAccess.Interfaces.Messages;
using LoveChat.DataAccess.Interfaces.Users;
using LoveChat.DataAccess.Repositories.Messages;
using LoveChat.DataAccess.Repositories.Users;

namespace LoveChat.WebApi.Configuration.Layers
{
    public static class DataAccessConfiguration
    {
        public static void ConfigureDataAccess(this WebApplicationBuilder builder)
        {
            //-> DI containers, IoC containers
            builder.Services.AddScoped<IMessagesRepository, MessageRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
