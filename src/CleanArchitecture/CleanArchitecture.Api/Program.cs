using CleanArchitecture.Api.Extensions;
using CleanArchitecture.Api.OptionsSetup;
using CleanArchitecture.Application;
using CleanArchitecture.Application.Abstractions.Authentication;
using CleanArchitecture.Infrastructure;
using CleanArchitecture.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((context, configuration) => 
configuration.ReadFrom.Configuration(context.Configuration)
);

builder.Services.AddControllers();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer();

builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();

builder.Services.AddTransient<IJwtProvider, JwtProvider>();

builder.Services.AddAuthorization();
builder.Services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();
builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>{
    options.CustomSchemaIds(type =>type.ToString());
});

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

await app.ApplyMigration();
app.SeedData();
app.SeedDataAuthentication();


app.UseRequestContextLogging();

app.UseSerilogRequestLogging();

app.UseCustomExceptionHandler();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

