using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using RecyclingBot.Control;
using RecyclingBot.Control.Handlers;
using Telegram.Bot.Framework;
using Telegram.Bot.Framework.Abstractions;

namespace RecyclingBot
{
  public class Startup
  {
    private readonly IConfiguration _configuration;

    public Startup(IHostingEnvironment env)
    {
      IConfigurationBuilder builder = new ConfigurationBuilder()
        .SetBasePath(env.ContentRootPath)
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
        .AddEnvironmentVariables();

      _configuration = builder.Build();
    }

    public void ConfigureServices(IServiceCollection services)
    {
      IConfigurationSection recyclingBotSection = _configuration.GetSection(RecyclingBotConfiguration.SectionName);

      //  Add bot
      services.AddRecyclingBot(recyclingBotSection);

      //  Add configuration
      services.AddSingleton(recyclingBotSection.Get<RecyclingBotConfiguration>());

      //  Add operation services
      services.AddOperationServices();
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseTelegramBotLongPolling<RecyclingBot>(ConfigureBot(), startAfter: TimeSpan.FromSeconds(2));
      }
      else
      {
        app.UseTelegramBotWebhook<RecyclingBot>(ConfigureBot());
        app.EnsureWebhookSet<RecyclingBot>();
      }

      app.Run(async context =>
      {
        await context.Response.WriteAsync("Hello World!");
      });
    }

    private IBotBuilder ConfigureBot()
    {
      return new BotBuilder()
        .Use<FaultedUpdateHandler>()
        .UseCommand<RecyclingBotCommand>("recycling");
    }
  }
}
