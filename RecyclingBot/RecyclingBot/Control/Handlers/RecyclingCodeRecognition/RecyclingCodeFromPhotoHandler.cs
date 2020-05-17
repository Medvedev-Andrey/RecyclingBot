using System.Collections.Generic;
using System.Security.Policy;
using RecyclingBot.Control.Common;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Framework.Abstractions;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace RecyclingBot.Control.Handlers.RecyclingCodeRecognition
{
  public class RecyclingCodeFromPhotoHandler : IUpdateHandler
  {
    internal static readonly HashSet<long> ChatIdsAwaitingForPhoto = new HashSet<long>(); 

    public static bool CanHandle(IUpdateContext context)
    {
      UpdateType updateType = context?.Update?.Type ?? UpdateType.Unknown;

      switch (updateType)
      {
        case UpdateType.Message:
        {
          return UpdateHandlerExtensions.IsCallbackCommand(context?.Update?.Message, Constants.RecyclingCodeFromPhotoCallbackCommand);
        }
        case UpdateType.CallbackQuery:
        {
          return UpdateHandlerExtensions.IsCallbackCommand(context?.Update?.CallbackQuery, Constants.RecyclingCodeFromPhotoCallbackCommand);
        }
      }

      return false;
    }

    public async Task HandleAsync(IUpdateContext context, UpdateDelegate next, CancellationToken cancellationToken)
    {
      UpdateType updateType = context?.Update?.Type ?? UpdateType.Unknown;

      switch (updateType)
      {
        case UpdateType.Message:
        {
          await context.Bot.Client.SendTextMessageAsync(
            chatId: context.Update.Message.Chat.Id,
            text: "Send a photo of the code"
          );

          ChatIdsAwaitingForPhoto.Add(context.Update.Message.Chat.Id);
          break;
        }

        case UpdateType.CallbackQuery:
        {
          await context.Bot.Client.EditMessageTextAsync(
            chatId: context.Update.CallbackQuery.Message.Chat.Id,
            messageId: context.Update.CallbackQuery.Message.MessageId,
            text: "Send a photo of the code",
            replyMarkup: InlineKeyboardMarkup.Empty()
          );

          ChatIdsAwaitingForPhoto.Add(context.Update.CallbackQuery.Message.Chat.Id);
          break;
        }
      }
    }
  }
}
