using System;
using System.Collections.Generic;
using System.Diagnostics;
using RecyclingBot.Properties;

namespace RecyclingBot.Control.Handlers.Wiki.FractionsInfo.Info
{
  public class PaperFractionInfo : IFractionInfo
  {
    public Guid Id
    {
      get;
    }

    public string Topic => FractionInfoResources.PaperFractionInfo_Topic;

    public IEnumerable<string> AllInfo
    {
      get
      {
        string whyCollectString = FractionInfoResources.PaperFractionInfo_WhyCollect;
        if (!string.IsNullOrWhiteSpace(whyCollectString))
        {
          yield return whyCollectString;
        }

        string howToRecycleString = FractionInfoResources.PaperFractionInfo_HowToRecycle;
        if (!string.IsNullOrWhiteSpace(howToRecycleString))
        {
          yield return howToRecycleString;
        }
      }
    }

    public PaperFractionInfo(Guid id)
    {
      Debug.Assert(id != null, $"Id for {GetType().Name} is null");
      Id = id;
    }
  }
}
