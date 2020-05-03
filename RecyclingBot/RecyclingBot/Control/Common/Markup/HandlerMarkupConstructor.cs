using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;

namespace RecyclingBot.Control.Common.Markup
{
  public static class HandlerMarkupConstructor
  {
    public static InlineKeyboardMarkup StartHandlerMarkup()
    {
      var keyboardRows = new List<IEnumerable<InlineKeyboardButton>>()
      {
        Row.CreateLabelRow("Wiki", Constants.CommandCallbackPrefix + Constants.WikiCallbackCommand),
        Row.CreateLabelRow("Recycling code recognition", Constants.CommandCallbackPrefix + Constants.RecyclingCodeRecognitionCallbackCommand),
        Row.CreateLabelRow("Search nearest waste container", Constants.CommandCallbackPrefix + Constants.WasteContainerSearchCallbackCommand)
      };

      return new InlineKeyboardMarkup(keyboardRows);
    }

    public static InlineKeyboardMarkup WikiHandlerMarkup()
    {
      var keyboardRows = new List<IEnumerable<InlineKeyboardButton>>()
      {
        Row.CreateLabelRow("Waste recycling tips", Constants.CommandCallbackPrefix + Constants.TipsCallbackCommand),
        Row.CreateLabelRow("Waste fraction info", Constants.CommandCallbackPrefix + Constants.FractionsInfoCallbackCommand),
        Row.CreateLabelRow("Helpful sources and links", Constants.CommandCallbackPrefix + Constants.SourcesCallbackCommand)
      };

      return new InlineKeyboardMarkup(keyboardRows);
    }

    public static InlineKeyboardMarkup TipsHandlerMarkup()
    {
      var keyboardRows = new List<IEnumerable<InlineKeyboardButton>>()
      {
        Row.CreateLabelRow("Random tip", Constants.CommandCallbackPrefix + Constants.RandomTipCallbackCommand),
        Row.CreateLabelRow("Search by words", Constants.CommandCallbackPrefix + Constants.SearchTipCallbackCommand),
        Row.CreateLabelRow("Theme navigation", Constants.CommandCallbackPrefix + Constants.NavigateTipsCallbackCommand)
      };

      return new InlineKeyboardMarkup(keyboardRows);
    }

    public static InlineKeyboardMarkup FractionsInfoHandlerMarkup()
    {
      var keyboardRows = new List<IEnumerable<InlineKeyboardButton>>()
      {
        Row.CreateLabelRow("Random fraction info", Constants.CommandCallbackPrefix + Constants.RandomFractionInfoCallbackCommand),
        Row.CreateLabelRow("Search by words", Constants.CommandCallbackPrefix + Constants.SearchFractionInfoCallbackCommand)
      };

      return new InlineKeyboardMarkup(keyboardRows);
    }

    public static InlineKeyboardMarkup RecyclingCodeRecognitionMarkup()
    {
      var keyboardRows = new List<IEnumerable<InlineKeyboardButton>>()
      {
        Row.CreateLabelRow("Search by code", Constants.CommandCallbackPrefix + Constants.RecyclingCodeSearchCallbackCommand),
        Row.CreateLabelRow("From photo", Constants.CommandCallbackPrefix + Constants.RecyclingCodeFromPhotoCallbackCommand)
      };

      return new InlineKeyboardMarkup(keyboardRows);
    }

    public static InlineKeyboardMarkup WasteContainerSearchMarkup()
    {
      var keyboardRow = Row.CreateLabelRow("Search by code");

      return new InlineKeyboardMarkup(keyboardRow);
    }
  }
}
