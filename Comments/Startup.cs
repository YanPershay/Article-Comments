using Article.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Article.Data.Interfaces;

namespace Comments
{
    public class Startup
    {
        private IConfigurationRoot _confString;

        public Startup(IHostEnvironment hostEnvironment)
        {
            _confString = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("dbSettings.json")
                .Build();
        }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<ArticleContext>(options => options
                    .UseSqlServer(_confString.GetConnectionString("DefaultConnection")));

            services.AddTransient<ICommentRepository, CommentRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            

            using (var scope = app.ApplicationServices.CreateScope())
            {
                ArticleContext context = scope.ServiceProvider.GetRequiredService<ArticleContext>();

                DbObjects.Init(context);
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Comment}/{action=Index}");
            });
        }
    }
}
