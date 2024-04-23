using Forum.Application.Accounts;
using Forum.Application.Comments;
using Forum.Application.Services;
using Forum.Application.Topics;
using Forum.Domain.Entities;
using Forum.Infrastructure.Comments;
using Forum.Infrastructure.Topics;
using Forum.Infrastructure.UOW;
using Forum.Infrastructure.Users;
using Forum.Persistence;
using Forum.Persistence.Identity;
using Forum.Persistence.Seed;
using Forum.Web.BackgroundServices;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Forum.Web
{
    public class Program
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddScoped<ITopicService, TopicService>();
            services.AddScoped<ITopicRepository, TopicRepository>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ICommentUOW, CommentUOW>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserManagementService, UserManagementService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<UserManager<User>>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddHostedService<BanUserBackgroundService>();
            services.AddHostedService<TopicArchivalBackgroundService>();
        }
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddHealthChecks();
            //builder.Services.AddSession(options =>
            //{
            //    options.IdleTimeout = TimeSpan.FromMinutes(20);
            //    options.Cookie.HttpOnly = true;
            //    options.Cookie.IsEssential = true;
            //});
            ConfigureServices(builder.Services);

            builder.Services.AddRazorPages();


            builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection(nameof(ConnectionStrings)));
            // builder.Services.AddDbContext<ForumContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(ConnectionStrings.DefaultConnection))));

            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(ConnectionStrings.DefaultConnection))));

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));

                options.AddPolicy("UserOnly", policy => policy.RequireRole("user"));

                options.AddPolicy("AdminAndUser", policy =>
                    policy.RequireAssertion(context =>
                        context.User.IsInRole("Admin") ||
                        context.User.IsInRole("User")));
            });

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
             .AddCookie(options =>
             {
                 options.LoginPath = "/Account/Login";
                 options.Cookie.Name = "AuthCookie";
             });


            builder.Services.AddIdentity<User, IdentityRole>(option =>
            {
                option.Password.RequireDigit = true;
                option.Password.RequiredLength = 8;
                option.Password.RequireUppercase = true;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

            // Register your services here
            var app = builder.Build();  

            app.UseHttpsRedirection();

            app.UseStaticFiles();
           // app.UseSession();
            app.UseRouting();
            app.MapHealthChecks("/api/health", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            });

            await DataSeeder.Initialize(app.Services);

            app.Run();

        }
        
    }
}
