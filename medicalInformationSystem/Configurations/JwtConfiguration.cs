using System.Text;
using medicalInformationSystem.Configurations.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace medicalInformationSystem.Configurations;

public class JwtConfiguration
{
    public static void AddApiAuthentication(IServiceCollection services, IOptions<JwtOptions> jwtOptions)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Value.SecretKey))

                };

                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        context.Token = context.Request.Cookies["secret-cookies"];
                        return Task.CompletedTask;
                    }
                };
            });

        services.AddAuthorization();
    }
}