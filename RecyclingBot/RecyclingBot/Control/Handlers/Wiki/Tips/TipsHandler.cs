using RecyclingBot.Control.Common;
using RecyclingBot.Control.Common.Markup;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Framework.Abstractions;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace RecyclingBot.Control.Handlers.Wiki.Tips
{
  public class TipsHandler : IUpdateHandler
  {
    public static bool CanHandle(IUpdateContext context)
    {
      UpdateType updateType = context?.Update?.Type ?? UpdateType.Unknown;

      switch (updateType)
      {
        case UpdateType.Message:
        {
          return UpdateHandlerExtensions.IsCallbackCommand(context?.Update?.Message, Constants.TipsCallbackCommand);
        }
        case UpdateType.CallbackQuery:
        {
          return UpdateHandlerExtensions.IsCallbackCommand(context?.Update?.CallbackQuery, Constants.TipsCallbackCommand);
        }
      }

      return false;
    }

    public async Task HandleAsync(IUpdateContext context, UpdateDelegate next, CancellationToken cancellationToken)
    {
      InlineKeyboardMarkup tipsReplyMarkup = HandlerMarkupConstructor.TipsHandlerMarkup();
      UpdateType updateType = context?.Update?.Type ?? UpdateType.Unknown;

      switch (updateType)
      {
        case UpdateType.Message:
        {
          await context.Bot.Client.SendTextMessageAsync(
            chatId: context.Update.Message.Chat.Id,
            text: "It's time to read a bit about waste recycling tips!",
            replyMarkup: tipsReplyMarkup
          );

          break;
        }

        case UpdateType.CallbackQuery:
        {
          await context.Bot.Client.EditMessageTextAsync(
            chatId: context.Update.CallbackQuery.Message.Chat.Id,
            messageId: context.Update.CallbackQuery.Message.MessageId,
            text: "It's time to read a bit about waste recycling tips!",
            replyMarkup: tipsReplyMarkup
          );

          break;
        }
      }
    }
  }
}
