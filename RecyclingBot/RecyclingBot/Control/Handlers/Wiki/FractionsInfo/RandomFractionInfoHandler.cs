using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RecyclingBot.Control.Common;
using RecyclingBot.Control.Handlers.Wiki.FractionsInfo.Info;
using RecyclingBot.Properties;
using Telegram.Bot.Framework.Abstractions;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace RecyclingBot.Control.Handlers.Wiki.FractionsInfo
{
  public class RandomFractionInfoHandler : IUpdateHandler
  {
    public static bool CanHandle(IUpdateContext context)
    {
      UpdateType updateType = context?.Update?.Type ?? UpdateType.Unknown;

      switch (updateType)
      {
        case UpdateType.Message:
        {
          return UpdateHandlerExtensions.IsCallbackCommand(context?.Update?.Message, Constants.RandomFractionInfoCallbackCommand);
        }
        case UpdateType.CallbackQuery:
        {
          return UpdateHandlerExtensions.IsCallbackCommand(context?.Update?.CallbackQuery, Constants.RandomFractionInfoCallbackCommand);
        }
      }

      return false;
    }

    public async Task HandleAsync(IUpdateContext context, UpdateDelegate next, CancellationToken cancellationToken)
    {
      int count = FractionsInfoWiki.Available.Count;
      if (count <= 0)
      {
        return;
      }

      //  Get random fraction info
      int randomFractionInfo = Randomizer.Instance.Next(0, count);
      IFractionInfo fractionInfo = FractionsInfoWiki.Available[randomFractionInfo];

      long chatId;
      UpdateType updateType = context?.Update?.Type ?? UpdateType.Unknown;
      if (updateType == UpdateType.CallbackQuery)
      {
        chatId = context.Update.CallbackQuery.Message.Chat.Id;
        await context.Bot.Client.EditMessageTextAsync(
            chatId: chatId,
            messageId: context.Update.CallbackQuery.Message.MessageId,
            text: fractionInfo.Topic,
            replyMarkup: InlineKeyboardMarkup.Empty()
          );
      }
      else
      {
        chatId = context.Update.Message.Chat.Id;
        await context.Bot.Client.SendTextMessageAsync(
              chatId: chatId,
              text: fractionInfo.Topic
            );
      }

      foreach (string fractionInfoItem in FractionsInfoHandler.FormatFractionInfo(fractionInfo))
      {
        await context.Bot.Client.SendTextMessageAsync(
              chatId: chatId,
              text: fractionInfoItem
            );
      }
    }
  }
}
