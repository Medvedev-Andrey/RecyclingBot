using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecyclingBot.Control;
using RecyclingBot.Control.Handlers;
using RecyclingBot.Control.Handlers.Wiki;
using RecyclingBot.Control.Handlers.Wiki.Tips;
using RecyclingBot.Control.Handlers.Wiki.FractionsInfo;
using RecyclingBot.Control.Handlers.Wiki.Sources;
using RecyclingBot.Control.Handlers.RecyclingCodeRecognition;
using System;
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
        .UseWhen<StartHandler>(StartHandler.CanHandle)
        .UseWhen<WikiHandler>(WikiHandler.CanHandle)
        .UseWhen<TipsHandler>(TipsHandler.CanHandle)
        .UseWhen<RandomTipHandler>(RandomTipHandler.CanHandle)
        .UseWhen<SearchTipHandler>(SearchTipHandler.CanHandle)
        .UseWhen<NavigateTipsHandler>(NavigateTipsHandler.CanHandle)
        .UseWhen<FractionsInfoHandler>(FractionsInfoHandler.CanHandle)
        .UseWhen<RandomFractionInfoHandler>(RandomFractionInfoHandler.CanHandle)
        .UseWhen<SearchFractionInfoHandler>(SearchFractionInfoHandler.CanHandle)
        .UseWhen<SourcesHandler>(SourcesHandler.CanHandle)
        .UseWhen<WasteContainerSearchHandler>(WasteContainerSearchHandler.CanHandle)
        .UseWhen<RecyclingCodeRecognitionHandler>(RecyclingCodeRecognitionHandler.CanHandle)
        .UseWhen<RecyclingCodeSearchHandler>(RecyclingCodeSearchHandler.CanHandle)
        .UseWhen<RecyclingCodeFromPhotoHandler>(RecyclingCodeFromPhotoHandler.CanHandle)
        .UseWhen<PhotoWithRecyclingCodeHandler>(PhotoWithRecyclingCodeHandler.CanHandle);
    }
  }
}
