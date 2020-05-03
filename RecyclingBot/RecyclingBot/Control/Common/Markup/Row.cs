using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;

namespace RecyclingBot.Control.Common.Markup
{
  public static class Row
  {
    public static IEnumerable<InlineKeyboardButton> CreateLabelRow(string text, string callbackData = null)
    {
      return new[]
      {
        InlineKeyboardButton.WithCallbackData(text, callbackData)
      };
    }
  }
}
