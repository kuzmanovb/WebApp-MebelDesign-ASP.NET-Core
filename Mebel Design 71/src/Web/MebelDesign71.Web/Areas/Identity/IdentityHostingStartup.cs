using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(MebelDesign71.Web.Areas.Identity.IdentityHostingStartup))]

namespace MebelDesign71.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => { });
        }
    }
}