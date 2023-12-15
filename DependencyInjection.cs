using System.ComponentModel.Design;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.SwaggerGen;
using UserRepository.Helper;
using UserRepository.Interfaces;
using UserRepository.Repository;
using UserRepository.Services;

namespace UserRepository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddScoped(this IServiceCollection services)
        {

            services.AddScoped<IGetClaim, GetClaim>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IUserRepository, UserRepository.Repository.UserRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<ICodeGenerator, CodeGenerator>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped(provider => provider.GetRequiredService<IHttpContextAccessor>().HttpContext.User);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            return services;
        }
        public static IServiceCollection AddConfiguration(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<HashSettings>(configuration.GetSection(HashSettings.SectionName));
            services.Configure<EmailSettings>(configuration.GetSection(EmailSettings.SectionName));
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

            return services;
        }

        public static IServiceCollection AddJwt(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            var jwtSettingsData = new JwtSettings();
            configuration.Bind(JwtSettings.SectionName, jwtSettingsData);
            services.AddSingleton(Options.Create(jwtSettingsData));
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerGetOptionConfiguration>();
            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                        .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                        {
                            // RoleClaimType = ClaimTypes.Role,
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = jwtSettingsData.Issuer,
                            ValidAudience = jwtSettingsData.Audience,
                            IssuerSigningKey = new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(jwtSettingsData.Secret))
                        });
            return services;
        }
    }

}