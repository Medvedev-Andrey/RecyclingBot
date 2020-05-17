using System;
using System.Linq;

namespace RecyclingBot.Control.Handlers.RecyclingCodeRecognition.CodeRecognition
{
  public class CodeRecognitionResult
  {
    public bool SuccessfullyProcessedImage
    {
      get; private set;
    }

    public float? PredictionScore
    {
      get; private set;
    }

    public string PredictedLabel
    {
      get; private set;
    }

    public Exception Exception
    {
      get; private set;
    }

    private CodeRecognitionResult()
    {
    }

    public static CodeRecognitionResult FromPrediction(ImagePrediction imagePrediction)
    {
      CodeRecognitionResult result = new CodeRecognitionResult();

      if (imagePrediction == null)
      {
        result.SuccessfullyProcessedImage = false;
      }
      else
      {
        result.SuccessfullyProcessedImage = true;
        result.PredictionScore = imagePrediction.Score.Max();
        result.PredictedLabel = imagePrediction.PredictedLabelValue;
      }

      return result;
    }

    public static CodeRecognitionResult FromException(Exception ex)
    {
      CodeRecognitionResult result = new CodeRecognitionResult()
      {
        SuccessfullyProcessedImage = false,
        Exception = ex
      };

      return result;
    }
  }
}
