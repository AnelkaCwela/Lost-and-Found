using LostNelsonFound.Models;
using LostNelsonFound.Models.DataModel;
using LostNelsonFound.Models.Interface;
using LostNelsonFound.Models.Resptory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LostNelsonFound
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
         //   services.AddControllersWithViews();
            services.AddDbContext<DBCONTEX>(options => options.UseSqlServer(Configuration["NelsonMandelaUniversty:ConnectionString"]));
            services.AddIdentity<UserPlusModel, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;

                options.SignIn.RequireConfirmedEmail = true;
            })
                .AddEntityFrameworkStores<DBCONTEX>()
                .AddDefaultTokenProviders()
                ;
            services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
.RequireAuthenticatedUser().Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            })
                .AddXmlDataContractSerializerFormatters();

            services.AddTransient<ICategoryModel, CategoryResp>();
            //services.AddTransient<ICommentModel, CommentResp>();
            services.AddTransient<IFoundModel, FoundResp>();
            services.AddTransient<IImageModel, ImageResp>();
            services.AddTransient<IPersonModel, PersonResp>();
            services.AddTransient<IStatuseModel, StatuseResp>();
  
            services.AddTransient<ICategoryLostModel, CategoryLostResp>();
           // services.AddTransient<ICommentLostModel, CommentLostResp>();
            services.AddTransient<ILostModel, LostResp>();
          //  services.AddTransient<IImageLostModel, ImageLostResp>();

            services.AddTransient<IStatuseLostModel, StatuseLostResp>();
  
            //services.AddTransient<IProfile, ProfileResp>();
            services.AddTransient<ICampus, CampusResp>();
            services.AddTransient<IBankCard, BankCardResp>();
            services.AddTransient<IIdentityCard, IdentityCardResp > ();
            services.AddTransient<IStudentCard, StudentCardResp>();
            services.AddTransient<IClaimModel, ClaimResp>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseSession();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Post}/{action=Post}/{id?}");
            });
        }
    }
}
