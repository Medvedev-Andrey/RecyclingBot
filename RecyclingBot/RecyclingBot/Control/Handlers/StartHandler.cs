using RecyclingBot.Control.Common;
using RecyclingBot.Control.Common.Markup;
using RecyclingBot.Control.Handlers;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Framework.Abstractions;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace RecyclingBot.Control
{
  public class StartHandler : IUpdateHandler
  {
    public static bool CanHandle(IUpdateContext context)
    {
      UpdateType updateType = context?.Update?.Type ?? UpdateType.Unknown;

      switch (updateType)
      {
        case UpdateType.Message:
        {
          return UpdateHandlerExtensions.IsCallbackCommand(context?.Update?.Message, Constants.StartCallbackCommand);
        }
        case UpdateType.CallbackQuery:
        {
          return UpdateHandlerExtensions.IsCallbackCommand(context?.Update?.CallbackQuery, Constants.StartCallbackCommand);
        }
      }

      return false;
    }

    public async Task HandleAsync(IUpdateContext context, UpdateDelegate next, CancellationToken cancellationToken)
    {
      InlineKeyboardMarkup startReplyMarkup = HandlerMarkupConstructor.StartHandlerMarkup();
      UpdateType updateType = context?.Update?.Type ?? UpdateType.Unknown;

      switch (updateType)
      {
        case UpdateType.Message:
        {
          await context.Bot.Client.SendTextMessageAsync(
            chatId: context.Update.Message.Chat.Id,
            text: "How may I help you?",
            replyMarkup: startReplyMarkup
          );

          break;
        }

        case UpdateType.CallbackQuery:
        {
          await context.Bot.Client.AnswerCallbackQueryAsync(
            callbackQueryId: context.Update.CallbackQuery.Id,
            text: "How may I help you?"
          );

          break;
        }
      }
    }
  }
}