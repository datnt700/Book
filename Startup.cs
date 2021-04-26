using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryBook.Models;
using LibraryBook.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace LibraryBook
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:3000")
                                                              .AllowAnyHeader()
                                                        .AllowAnyMethod();
                                  });
            });

            services.AddDbContext<BookDBContext>(opts =>
            opts.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("sqlConnection")));
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<ICategory, CategoryService>();
            services.AddTransient<IUser, UserService>();
            services.AddTransient<IBookBorrowingRequestService, BookBorrowingRequestService>();
            services.AddTransient<IRequestDetail, RequestDetail>();
            services.AddControllers()
                    .AddNewtonsoftJson(opts => opts.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LibraryBook", Version = "v1" });
            });
            services.Configure<CookiePolicyOptions>(option => 
            {
                option.CheckConsentNeeded = context => true;
                option.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LibraryBook v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCookiePolicy();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseCors(MyAllowSpecificOrigins);


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
