using Microsoft.AspNetCore.Authentication.JwtBearer;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication().AddJwtBearer("OcelotAuthanticationScheme", options =>
{
	options.Authority = builder.Configuration["IdentityServerUrl"];
	options.Audience = "ResourceOcelot";
	options.RequireHttpsMetadata = false; // For development purposes only, set to true in production
});


IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("ocelot.json").Build();
builder.Services.AddOcelot(configuration);


var app = builder.Build();

await app.UseOcelot();
app.MapGet("/", () => "Hello World!");

app.Run();
