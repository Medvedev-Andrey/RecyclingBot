using System;
using System.Collections.Generic;
using System.Diagnostics;
using RecyclingBot.Properties;

namespace RecyclingBot.Control.Handlers.Wiki.FractionsInfo.Info
{
  public class MetalFractionInfo : IFractionInfo
  {
    public Guid Id
    {
      get;
    }

    public string Topic => FractionInfoResources.MetalFractionInfo_Topic;

    public IEnumerable<string> AllInfo
    {
      get
      {
        string whyCollectString = FractionInfoResources.MetalFractionInfo_WhyCollect;
        if (!string.IsNullOrWhiteSpace(whyCollectString))
        {
          yield return whyCollectString;
        }

        string howToRecycleString = FractionInfoResources.MetalFractionInfo_HowToRecycle;
        if (!string.IsNullOrWhiteSpace(howToRecycleString))
        {
          yield return howToRecycleString;
        }
      }
    }

    public MetalFractionInfo(Guid id)
    {
      Debug.Assert(id != null, $"Id for {GetType().Name} is null");
      Id = id;
    }
  }
}
