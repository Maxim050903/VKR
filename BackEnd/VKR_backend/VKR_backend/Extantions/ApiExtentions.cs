using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace VKR_backend.Extantions
{
    public static class ApiExtentions
    {
        public static void AddAPIAuthentication(
            this IServiceCollection services,
            JwtOptions jwtOption
            )
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
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOption.SecretKey))
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            context.Token = context.Request.Cookies["token"];

                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddAuthorization();

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("AdminPolicy", policy =>
            //    {
            //        policy.RequireClaim("Role", "Admin");
            //    });
            //    options.AddPolicy("UserPolicy", policy =>
            //    {
            //        policy.RequireClaim("Role", "User");
            //    });
            //    options.AddPolicy("BossPolicy", policy =>
            //    {
            //        policy.RequireClaim("Role", "Boss");
            //    });
            
            //});
        }
    }
}
