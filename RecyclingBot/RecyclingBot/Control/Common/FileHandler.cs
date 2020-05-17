using System;
using System.IO;
using System.Threading.Tasks;
using Telegram.Bot;
using File = Telegram.Bot.Types.File;

namespace RecyclingBot.Control.Common
{
  public class FileHandler : IDisposable
  {
    public string FilePath
    {
      get;
    }

    protected FileHandler(string filePath)
    {
      FilePath = filePath;
    }

    public static async Task<string> DownloadFile(ITelegramBotClient botClient, File file, long chatId)
    {
      try
      {
        string originalPath = file.FilePath;
        string fileName = originalPath.Substring(originalPath.LastIndexOf("/", StringComparison.Ordinal) + 1);
        string pathToFile = $"{chatId}_{fileName}";
        using (FileStream outputFile = System.IO.File.Create(pathToFile))
        {
          await botClient.DownloadFileAsync(originalPath, outputFile);
        }

        return pathToFile;
      }
      catch (Exception e)
      {
        //  Ignore
      }

      return null;
    }

    public void Dispose()
    {
      try
      {
        if (System.IO.File.Exists(FilePath))
        {
          System.IO.File.Delete(FilePath);
        }
      }
      catch (Exception e)
      {
        // Ignored
      }
    }
  }
}
