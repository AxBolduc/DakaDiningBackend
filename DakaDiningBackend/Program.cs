using System.Text.Json.Serialization;
using DakaDiningBackend.Auth.Services;
using DakaDiningBackend.Entities;
using DakaDiningBackend.MealOffers.Mappers;
using DakaDiningBackend.MealOffers.Services;
using DakaDiningBackend.MealRequests.Mappers;
using DakaDiningBackend.MealRequests.Services;
using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddFastEndpoints()
    .AddDbContext<DakaContext>(options => { options.UseNpgsql(builder.Configuration.GetConnectionString("supabase")); })
    .AddJWTBearerAuth("THIS_IS_A_SECRET")
    .AddAuthorization()
    .AddScoped<IUserService, UserService>()
    .AddScoped<IOffersService, OffersService>()
    .AddScoped<IMealRequestsService, MealRequestsService>()
    .AddSingleton<OfferEntityToOfferMapper>()
    .AddSingleton<RequestEntityToRequestMapper>()
    .SwaggerDocument();

var app = builder.Build();

app
    .UseAuthentication()
    .UseAuthorization()
    .UseFastEndpoints(c =>
    {
        c.Serializer.Options.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    })
    .UseSwaggerGen();

app.Run();

public partial class Program
{
}
