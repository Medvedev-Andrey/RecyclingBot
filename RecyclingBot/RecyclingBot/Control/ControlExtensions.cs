using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecyclingBot.Control.Handlers;
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
        .AddScoped<RecyclingBotCommand>();
    }

    public static IServiceCollection AddOperationServices(this IServiceCollection services)
    {
      return services;
    }
  }
}