using System;
using Microsoft.ML;

namespace RecyclingBot.Control.Handlers.RecyclingCodeRecognition.CodeRecognition
{
  public sealed class CodeRecognitionModelController
  {
    private static readonly Lazy<CodeRecognitionModelController> _lazyInstance 
      = new Lazy<CodeRecognitionModelController>(() => new CodeRecognitionModelController());

    private readonly PredictionEngine<ImageData, ImagePrediction> _predictionEngine;

    public static CodeRecognitionModelController Instance => _lazyInstance.Value;

    public bool CanProcessImage => _predictionEngine != null;

    private CodeRecognitionModelController()
    {
      _predictionEngine = null;
    }

    public CodeRecognitionResult Recognize(ImageData imageData)
    {
      if (!CanProcessImage)
      {
        return null;
      }

      ImagePrediction imagePrediction;

      try
      {
        imagePrediction = _predictionEngine.Predict(imageData);
      }
      catch (Exception ex)
      {
        return CodeRecognitionResult.FromException(ex);
      }

      return CodeRecognitionResult.FromPrediction(imagePrediction);
    }
  }
}
