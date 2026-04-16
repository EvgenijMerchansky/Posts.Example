using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Posts.Example.CommandApi.Site.Extensions;
using Posts.Example.CommandApi.Site.Validators;
using Posts.Example.CommandService.CommandHandlers;
using Posts.Example.DBLayer.EntityFramework;
using Posts.Example.QueryService.QueryHandlers;
using Posts.Example.Utilities.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(cfg => cfg.AddMaps(typeof(MapperProfile).Assembly));
builder.Services.AddDbContext<PostsDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.AddServices();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetPostQueryHandler).Assembly, typeof(CreatePostCommandHadnler).Assembly));
builder.Services.AddValidatorsFromAssemblyContaining(typeof(PostDtoValidator));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<PostsDbContext>();
    await context.Database.EnsureCreatedAsync();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
