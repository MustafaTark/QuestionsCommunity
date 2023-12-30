
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Identity.Web;
using Domain.Models.Identity;
using Infrastructure.Data;
using Infrastructure.Contracts;
using Infrastructure.Repositories;
using MediatR;
using Application.Questions.Commands.Create;
using Infrastructure.Common;
using Application.Questions.Queries.GetAll;
using Domain.Dto.Questions;
using Application.Comminuties.Commands.Create;
using Application.Comminuties.Queries.GetAll;
using Domain.Dto.Community;
using Application.Tags.Commands.Create;
using Application.Tags.Queries.GetAll;
using Domain.Dto.Tags;

namespace BrightWeb.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services,
        IConfiguration configuration)
         => services.AddDbContext<AppDbContext>(opts =>
                                    opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")
                                    , b =>b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

        public static void ConfigureIdentity<T>(this IServiceCollection services) where T : User
        {
            var authBuilder = services.AddIdentityCore<T>
                (o =>
                {
                    o.Password.RequireDigit = true;
                    o.Password.RequireLowercase = false;
                    o.Password.RequireUppercase = false;
                    o.Password.RequireNonAlphanumeric = false;
                    o.Password.RequiredLength = 10;
                    o.User.RequireUniqueEmail = true;
                });
            authBuilder = new IdentityBuilder(authBuilder.UserType, typeof(IdentityRole), services);
            authBuilder.AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
        }
        public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = Encoding.UTF8.GetBytes("BrightWaySecretAPIKeyValueToStoreInServer");
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(
                options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.GetSection("validIssuer").Value,
                        ValidAudience = jwtSettings.GetSection("validAudience").Value,
                        IssuerSigningKey = new SymmetricSecurityKey(secretKey)
                    };
                })
                .AddMicrosoftIdentityWebApi(configuration.GetSection("AzureAd"), "jwtBearerScheme2");

        }

        public static void ConfigureLifeTime(this IServiceCollection services)
        {
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IRequestHandler<CreateQuestionCommand>, CreateQuestionCommandHandller>();
            services.AddScoped<IRequestHandler<GetAllQuestionsQuery, IEnumerable<QuestionDto>>, GetAllQuestionsQueryHandler>();
            
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IRequestHandler<CreateTagCommand>, CreateTagCommandHandller>();
            services.AddScoped<IRequestHandler<GetAllTagsQuery, IEnumerable<TagDto>>, GetAllTagsQueryHandeller>();

            services.AddScoped<ICommunityRepository, CommunityRepository>();
            services.AddScoped<IRequestHandler<CreateCommunityCommand>, CreateCommunityCommandHandller>();
            services.AddScoped<IRequestHandler<GetAllCommunitiesQuery, IEnumerable<CommunityDto>>, GetAllCommmunityQueryHandller>();
            services.AddScoped<IFilesManager, FilesManager>();
           
           
        }
    }
}
