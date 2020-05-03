using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecyclingBot.Control.Handlers;
using RecyclingBot.Control.Handlers.Wiki;
using RecyclingBot.Control.Handlers.Wiki.Tips;
using RecyclingBot.Control.Handlers.Wiki.FractionsInfo;
using RecyclingBot.Control.Handlers.Wiki.Sources;
using RecyclingBot.Control.Handlers.RecyclingCodeRecognition;
using RecyclingBot.Options;
using Telegram.Bot.Framework;

namespace RecyclingBot.Control
{
  public static class ControlExtensions
  {
    public static IServiceCollection AddRecyclingBot(this IServiceCollection services,
      IConfigurationSection botConfiguration)
    {
      return services.AddTransient<RecyclingBot>()
        .Configure<BotOptions<RecyclingBot>>(botConfiguration)
        .Configure<CustomBotOptions<RecyclingBot>>(botConfiguration)
        .AddScoped<FaultedUpdateHandler>()
        .AddScoped<StartHandler>()
        .AddScoped<WikiHandler>()
        .AddScoped<TipsHandler>()
        .AddScoped<RandomTipHandler>()
        .AddScoped<SearchTipHandler>()
        .AddScoped<NavigateTipsHandler>()
        .AddScoped<FractionsInfoHandler>()
        .AddScoped<RandomFractionInfoHandler>()
        .AddScoped<SearchFractionInfoHandler>()
        .AddScoped<SourcesHandler>()
        .AddScoped<WasteContainerSearchHandler>()
        .AddScoped<RecyclingCodeRecognitionHandler>()
        .AddScoped<RecyclingCodeSearchHandler>()
        .AddScoped<RecyclingCodeFromPhotoHandler>();
    }

    public static IServiceCollection AddOperationServices(this IServiceCollection services)
    {
      return services;
    }
  }
}