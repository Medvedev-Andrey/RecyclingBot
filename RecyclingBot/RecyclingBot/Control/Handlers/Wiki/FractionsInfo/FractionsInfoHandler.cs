using RecyclingBot.Control.Common;
using RecyclingBot.Control.Common.Markup;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Framework.Abstractions;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace RecyclingBot.Control.Handlers.Wiki.FractionsInfo
{
  public class FractionsInfoHandler : IUpdateHandler
  {
    public static bool CanHandle(IUpdateContext context)
    {
      UpdateType updateType = context?.Update?.Type ?? UpdateType.Unknown;

      switch (updateType)
      {
        case UpdateType.Message:
        {
          return UpdateHandlerExtensions.IsCallbackCommand(context?.Update?.Message, Constants.FractionsInfoCallbackCommand);
        }
        case UpdateType.CallbackQuery:
        {
          return UpdateHandlerExtensions.IsCallbackCommand(context?.Update?.CallbackQuery, Constants.FractionsInfoCallbackCommand);
        }
      }

      return false;
    }

    public async Task HandleAsync(IUpdateContext context, UpdateDelegate next, CancellationToken cancellationToken)
    {
      InlineKeyboardMarkup wikiReplyMarkup = HandlerMarkupConstructor.FractionsInfoHandlerMarkup();
      UpdateType updateType = context?.Update?.Type ?? UpdateType.Unknown;

      switch (updateType)
      {
        case UpdateType.Message:
        {
          await context.Bot.Client.SendTextMessageAsync(
            chatId: context.Update.Message.Chat.Id,
            text: "Let's learn something about waste fractions!",
            replyMarkup: wikiReplyMarkup
          );

          break;
        }

        case UpdateType.CallbackQuery:
        {
          await context.Bot.Client.EditMessageTextAsync(
            chatId: context.Update.CallbackQuery.Message.Chat.Id,
            messageId: context.Update.CallbackQuery.Message.MessageId,
            text: "Let's learn something about waste fractions!",
            replyMarkup: wikiReplyMarkup
          );

          break;
        }
      }
    }
  }
}
