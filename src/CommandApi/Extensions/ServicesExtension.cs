using Posts.Example.DBLayer.Repositories;
using Posts.Example.DBLayer.Repositories.Interfaces;
using Posts.Example.Services.Services;

namespace Posts.Example.CommandApi.Site.Extensions;

public static class ServicesExtension
{
    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IPostService, PostService>();
        builder.Services.AddScoped<IMockPostService, MockPostService>();
        builder.Services.AddScoped<IPostRepository, PostRepository>();
    }
}
