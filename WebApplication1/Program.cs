using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Auth.Basic;
using WebApplication1.Auth.Basic.Handler;
using WebApplication1.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WebApplication1Context>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("WebApplication1Context") ?? throw new InvalidOperationException("Connection string 'WebApplication1Context' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition(Defaults.Scheme, Defaults.SecurityScheme);
    options.AddSecurityRequirement(Defaults.SecurityRequirement);
});

builder.Services
    .AddAuthentication()
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>(Defaults.Scheme, null);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
