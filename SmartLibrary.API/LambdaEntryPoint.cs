using Amazon.Lambda.AspNetCoreServer;

namespace SmartLibrary.API
{
    public class LambdaEntryPoint : APIGatewayHttpApiV2ProxyFunction 
    {
        protected override void Init(IWebHostBuilder builder)
        {
            //base.Init(builder);
            builder.UseStartup<Startup>();
        }
    }
}
