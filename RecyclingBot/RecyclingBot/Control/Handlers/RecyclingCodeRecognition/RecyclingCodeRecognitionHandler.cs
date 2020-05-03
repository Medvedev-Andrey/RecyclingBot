using RecyclingBot.Control.Common;
using RecyclingBot.Control.Common.Markup;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Framework.Abstractions;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace RecyclingBot.Control.Handlers.RecyclingCodeRecognition
{
  public class RecyclingCodeRecognitionHandler : IUpdateHandler
  {
    public static bool CanHandle(IUpdateContext context)
    {
      UpdateType updateType = context?.Update?.Type ?? UpdateType.Unknown;

      switch (updateType)
      {
        case UpdateType.Message:
        {
          return UpdateHandlerExtensions.IsCallbackCommand(context?.Update?.Message, Constants.RecyclingCodeRecognitionCallbackCommand);
        }
        case UpdateType.CallbackQuery:
        {
          return UpdateHandlerExtensions.IsCallbackCommand(context?.Update?.CallbackQuery, Constants.RecyclingCodeRecognitionCallbackCommand);
        }
      }

      return false;
    }

    public async Task HandleAsync(IUpdateContext context, UpdateDelegate next, CancellationToken cancellationToken)
    {
      InlineKeyboardMarkup recyclingCodeRecognitionMarkup = HandlerMarkupConstructor.RecyclingCodeRecognitionMarkup();
      UpdateType updateType = context?.Update?.Type ?? UpdateType.Unknown;

      switch (updateType)
      {
        case UpdateType.Message:
        {
          await context.Bot.Client.SendTextMessageAsync(
            chatId: context.Update.Message.Chat.Id,
            text: "Select the way you want to input code",
            replyMarkup: recyclingCodeRecognitionMarkup
          );

          break;
        }

        case UpdateType.CallbackQuery:
        {
          await context.Bot.Client.EditMessageTextAsync(
            chatId: context.Update.CallbackQuery.Message.Chat.Id,
            messageId: context.Update.CallbackQuery.Message.MessageId,
            text: "Select the way you want to input code",
            replyMarkup: recyclingCodeRecognitionMarkup
          );

          break;
        }
      }
    }
  }
}