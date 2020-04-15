using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Telegram.Bot.Framework;

namespace RecyclingBot
{
  public class RecyclingBot : BotBase
  {
    private readonly ILogger<RecyclingBot> _logger;

    public RecyclingBot(IOptions<BotOptions<RecyclingBot>> botOptions, ILogger<RecyclingBot> logger)
      : base(botOptions.Value)
    {
      _logger = logger;
    }
  }
}
