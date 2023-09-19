using LoveChat.DataAccess.Interfaces.Messages;
using LoveChat.DataAccess.Repositories.Messages;
using LoveChat.Service.Interfaces.Auth;

namespace LoveChat.WebApi.Configuration.Layers
{
    public static class ServiceLayerConfiguration
    {
        public static void ConfigureServiceLayer(this WebApplicationBuilder builder)
        {
            //-> DI containers, IoC containers
            builder.Services.AddScoped<IFileService, FileService>();
            builder.Services.AddScoped<IMessagesRepository, MessageRepository>();
            builder.Services.AddScoped<ICompanyService, CompanyService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<IPaginator, Paginator>();
            builder.Services.AddSingleton<ISmsSender, SmsSender>();
            builder.Services.AddScoped<IIdentityService, IdentityService>();
        }
    }
}
