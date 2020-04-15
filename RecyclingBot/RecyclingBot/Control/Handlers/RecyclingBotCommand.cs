using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Framework.Abstractions;

namespace RecyclingBot.Control.Handlers
{
  public class RecyclingBotCommand : CommandBase
  {
    public override async Task HandleAsync(
      IUpdateContext context,
      UpdateDelegate next,
      string[] args,
      CancellationToken cancellationToken
    )
    {
      await context.Bot.Client.SendTextMessageAsync(
        context.Update.Message.Chat.Id,
        "Response!",
        cancellationToken: cancellationToken
      );
    }
  }
}