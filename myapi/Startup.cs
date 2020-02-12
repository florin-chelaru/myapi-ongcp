using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using myapi.Data;
using MySql.Data.EntityFrameworkCore;
using System;

namespace myapi
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration
    {
      get;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();
      //services.AddAuthentication().AddGoogle(options =>
      //{
      //  options.ClientId = "344769217783-1ocea9vhvkssqd6e05retkg86c0jn9ta.apps.googleusercontent.com";
      //  options.ClientSecret = "iXWEjC6ACbs6_9TrhJBHziCf";
      //});
      // TODO: Next, continue to go through this doc https://www.tektutorialshub.com/asp-net-core/asp-net-core-identity-tutorial/ and
      //       this series of tutorials: https://www.youtube.com/watch?v=fgzRnlB992s and https://csharp-video-tutorials.blogspot.com/2019/09/external-identity-providers-in-aspnet_20.html
      //services.AddIdentity<IdentityUser, IdentityRole>();
      //services.AddDefaultIdentity<IdentityUser>();

      //services.AddDbContextPool<AppDbContext>(
      //options => options.UseMySQL(Configuration.GetConnectionString("MyApiMySqlConnection")));
      var connectionString = Environment.GetEnvironmentVariable("MYSQL_CONNECTION_STRING");
      services.AddDbContextPool<AppDbContext>(options => options.UseMySQL(connectionString));
      //options => options.UseSqlServer(Configuration.GetConnectionString("MyApiDbConnection")));

      services.AddTransient<IDiceRepository, MySqlDiceRepository>();

      // Next: https://cloud.google.com/sql/docs/mysql/connect-kubernetes-engine
      // Also: save to Git. But not the password to the database.
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      //app.UseAuthentication();
      //app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
