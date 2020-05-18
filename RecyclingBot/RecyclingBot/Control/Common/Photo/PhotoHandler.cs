using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Framework.Abstractions;
using Telegram.Bot.Types;

namespace RecyclingBot.Control.Common.Photo
{
  public class PhotoHandler : FileHandler
  {
    private PhotoHandler(string filePath)
    : base(filePath)
    { }

    public static async Task<PhotoHandler> FromMessage(IUpdateContext context, Message message)
    {
      long chatId = message?.Chat?.Id ?? -1;
      ITelegramBotClient botClient = context?.Bot?.Client;
      if (message == null || botClient == null || chatId < 0)
      {
        return null;
      }

      PhotoSize photoSize = message.Photo.OrderByDescending(p => p.FileSize).First();

      Telegram.Bot.Types.File file = await botClient.GetFileAsync(photoSize.FileId);
      if (file != null)
      {
        string downloadedFilePath = await DownloadFile(botClient, file, chatId);
        if (!string.IsNullOrWhiteSpace(downloadedFilePath))
        {
          return new PhotoHandler(downloadedFilePath);
        }
      }

      return null;
    }
  }
}
