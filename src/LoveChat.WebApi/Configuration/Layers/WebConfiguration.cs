namespace LoveChat.WebApi.Configuration.Layers
{
    public static class WebConfiguration
    {
        public static void ConfigureWeb(this WebApplicationBuilder builder)
        {
            builder.ConfigureJwtAuth();
            builder.ConfigureSwaggerAuth();
            builder.ConfigureCORSPolicy();
        }
    }
}
