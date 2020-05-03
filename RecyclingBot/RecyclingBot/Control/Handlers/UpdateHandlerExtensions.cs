using RecyclingBot.Control.Common;
using System;
using Telegram.Bot.Types;

namespace RecyclingBot.Control.Handlers
{
  public static class UpdateHandlerExtensions
  {
    public static bool IsCallbackCommand(this Message message, string command)
    {
      string messageText = message?.Text;
      if (string.IsNullOrWhiteSpace(messageText))
      {
        return false;
      }

      return IsCallbackCommand(messageText, command);
    }

    public static bool IsCallbackCommand(this CallbackQuery callbackQuery, string command)
    {
      string callbackQueryData = callbackQuery?.Data;
      if (string.IsNullOrWhiteSpace(callbackQueryData))
      {
        return false;
      }

      return IsCallbackCommand(callbackQueryData, command);
    }

    private static bool IsCallbackCommand(string data, string command)
    {
      if (data.StartsWith(Constants.CommandCallbackPrefix))
      {
        //  Skip only one text command prefix
        data = data.Substring(1);
      }

      return data.Equals(command, StringComparison.Ordinal);
    }
  }
}
