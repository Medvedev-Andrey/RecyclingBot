using System.Drawing;
using System.Security.Policy;
using System.Threading;
using System.Threading.Tasks;
using RecyclingBot.Control.Common;
using RecyclingBot.Control.Common.Markup;
using RecyclingBot.Control.Common.Photo;
using RecyclingBot.Control.Handlers.RecyclingCodeRecognition.CodeRecognition;
using Telegram.Bot.Framework.Abstractions;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace RecyclingBot.Control.Handlers.RecyclingCodeRecognition
{
  public class PhotoWithRecyclingCodeHandler : IUpdateHandler
  {
    public static bool CanHandle(IUpdateContext context)
    {
      UpdateType updateType = context?.Update?.Type ?? UpdateType.Unknown;

      if (updateType == UpdateType.Message)
      {
        bool hasPhoto = (context?.Update?.Message?.Photo?.Length ?? 0) > 0;
        if (hasPhoto)
        {
          long chatId = context?.Update?.Message?.Chat?.Id ?? -1;
          return RecyclingCodeFromPhotoHandler.ChatIdsAwaitingForPhoto.Contains(chatId);
        }
      }

      return false;
    }

    public async Task HandleAsync(IUpdateContext context, UpdateDelegate next, CancellationToken cancellationToken)
    {
      long chatId = context?.Update?.Message?.Chat?.Id ?? -1;
      RecyclingCodeFromPhotoHandler.ChatIdsAwaitingForPhoto.Remove(chatId);

      if (!CodeRecognitionModelController.Instance.CanProcessImage)
      {
        await context.Bot.Client.SendTextMessageAsync(
          chatId: context.Update.Message.Chat.Id,
          text: "Can't process photos"
        );

        return;
      }

      using (PhotoHandler photoHandler = await PhotoHandler.FromMessage(context, context?.Update?.Message))
      {
        if (photoHandler == null)
        {
          await context.Bot.Client.SendTextMessageAsync(
            chatId: context.Update.Message.Chat.Id,
            text: "Can't download photo"
          );

          return;
        }

        ImageData imageData = new ImageData
        {
          ImagePath = photoHandler.FilePath
        };

        CodeRecognitionResult codeRecognitionResult = CodeRecognitionModelController.Instance.Recognize(imageData);
        if (codeRecognitionResult == null || !codeRecognitionResult.SuccessfullyProcessedImage)
        {
          await context.Bot.Client.SendTextMessageAsync(
            chatId: context.Update.Message.Chat.Id,
            text: "Failed code recognition"
          );

          return;
        }

        await context.Bot.Client.SendTextMessageAsync(
          chatId: context.Update.Message.Chat.Id,
          text: $"Recognized {codeRecognitionResult.PredictedLabel} with score: {codeRecognitionResult.PredictionScore}"
        );
      }
    }
  }
}
