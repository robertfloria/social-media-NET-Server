using DapperServer.Common.Helper;
using DapperServer.Common.Settings;
using DapperServer.DataAccessLayer;
using DapperServer.ServiceLayer;
using DapperServer.ServiceLayer.Authorization;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;
using DapperServer.Common.Interfaces;
using DapperServer.Common.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var services = builder.Services;
var environment = builder.Environment;
var configuration = builder.Configuration;

var MyAllowSpecificOrigins = "MyAllowSpecificOrigins";

services.AddCors(options =>
{
    options.AddPolicy("MyAllowSpecificOrigins",
                        policy =>
                        {
                            policy.WithOrigins("http://localhost:3004")
                                  .AllowAnyHeader()
                                  .AllowAnyMethod()
                                  .AllowCredentials();
                        });
});

services.AddControllers();
services.AddEndpointsApiExplorer();

services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "Deposit app",
                    Description = "API folosit pentru aplicatia depozite.",
                    Contact = new OpenApiContact
                    {
                        Name = "Robert",
                        Email = "robertfloria27@gmail.com"
                    }
                });

    //c.AddSecurityDefinition("Bearer",
    //        new OpenApiSecurityScheme
    //        {
    //            In = ParameterLocation.Header,
    //            Description = "Please enter a valid token",
    //            Name = "Authorization",
    //            Type = SecuritySchemeType.Http,
    //            BearerFormat = "JWT",
    //            Scheme = "Bearer"
    //        });
    //c.AddSecurityRequirement(new OpenApiSecurityRequirement
    //    {
    //        {
    //            new OpenApiSecurityScheme
    //            {
    //                Reference = new OpenApiReference
    //                {
    //                    Type=ReferenceType.SecurityScheme,
    //                    Id="Bearer"
    //                }
    //            },
    //            new string[]{}
    //        }
    //    });
    c.UseInlineDefinitionsForEnums();
});

/// configure automapper with all automapper profiles from this assembly
/// 
services.AddAutoMapper(typeof(Program));

/// configure strongly typed settings object
services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
services.AddScoped<IJwtUtils, JwtUtils>();

services.AddScoped<IAesEncryptionService, AesEncryptionService>();
DataConfiguration.DataDependencies(services);
ServicesConfiguration.ServicesDependencies(services);


var app = builder.Build();

app.UseRouting();

/// global cors policy
app.UseCors("MyAllowSpecificOrigins");

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

//app.UseStaticFiles();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

/// global error handler
app.UseMiddleware<ErrorHandlerMiddleware>();

/// custom jwt auth middleware
app.UseMiddleware<JwtMiddleware>();

app.Run();
