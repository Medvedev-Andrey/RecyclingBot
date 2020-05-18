using System;
using Microsoft.Extensions.Options;
using Microsoft.ML;
using RecyclingBot.Options;

namespace RecyclingBot.Control.Handlers.RecyclingCodeRecognition.CodeRecognition
{
  public sealed class CodeRecognitionModelController
  {
    private readonly PredictionEngine<ImageData, ImagePrediction> _predictionEngine;

    public bool CanProcessImage => _predictionEngine != null;

    public CodeRecognitionModelController(IOptions<CustomBotOptions<RecyclingBot>> options)
    {
      _predictionEngine = LoadPredictionEngine(options.Value.CodeRecognitionModelFileName);
    }

    private PredictionEngine<ImageData, ImagePrediction> LoadPredictionEngine(string modelFileName)
    {
      try
      {
        DataViewSchema modelSchema;
        MLContext mlContext = new MLContext();
        ITransformer trainedModel = mlContext.Model.Load(modelFileName, out modelSchema);
        return mlContext.Model.CreatePredictionEngine<ImageData, ImagePrediction>(trainedModel);
      }
      catch
      {
        //  Ignore
      }

      return null;
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
