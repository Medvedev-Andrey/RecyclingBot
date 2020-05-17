using Microsoft.ML.Data;

namespace RecyclingBot.Control.Handlers.RecyclingCodeRecognition.CodeRecognition
{
  public class ImageData
  {
    [LoadColumn(0)]
    public string ImagePath;

    [LoadColumn(1)]
    public string Label;
  }
}
