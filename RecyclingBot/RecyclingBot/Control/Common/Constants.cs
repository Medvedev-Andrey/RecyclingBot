namespace RecyclingBot.Control.Common
{
  public static class Constants
  {
    public const string CommandCallbackPrefix = "/";
    public const string StartCallbackCommand = "start";

    #region Start menu commands
    public const string WikiCallbackCommand = "wiki";

    #region Wiki menu commands
    public const string TipsCallbackCommand = "tips";

    #region Tips menu commands
    public const string RandomTipCallbackCommand = "tips_random";
    public const string SearchTipCallbackCommand = "tips_search";
    public const string NavigateTipsCallbackCommand = "tips_navigate";
    #endregion Tips menu commands

    public const string FractionsInfoCallbackCommand = "fractions";

    #region Fractions info menu commands
    public const string RandomFractionInfoCallbackCommand = "fractions_random";
    public const string SearchFractionInfoCallbackCommand = "fractions_search";
    #endregion Fractions info menu commands

    public const string SourcesCallbackCommand = "sources";
    #endregion Wiki menu commands

    public const string RecyclingCodeRecognitionCallbackCommand = "code_recognition";

    #region Recycling code recognition menu commands
    public const string RecyclingCodeSearchCallbackCommand = "code_search";
    public const string RecyclingCodeFromPhotoCallbackCommand = "code_from_photo";
    #endregion Recycling code recognition menu commands

    public const string WasteContainerSearchCallbackCommand = "container_search";
    #endregion Start menu commands
  }
}
