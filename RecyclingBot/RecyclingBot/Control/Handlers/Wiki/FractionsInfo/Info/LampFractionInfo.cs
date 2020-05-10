using System;
using System.Collections.Generic;
using System.Diagnostics;
using RecyclingBot.Properties;

namespace RecyclingBot.Control.Handlers.Wiki.FractionsInfo.Info
{
  public class LampFractionInfo : IFractionInfo
  {
    public Guid Id
    {
      get;
    }

    public string Topic => FractionInfoResources.LampFractionInfo_Topic;

    public IEnumerable<string> AllInfo
    {
      get
      {
        string whyCollectString = FractionInfoResources.LampFractionInfo_WhyCollect;
        if (!string.IsNullOrWhiteSpace(whyCollectString))
        {
          yield return whyCollectString;
        }

        string howToRecycleString = FractionInfoResources.LampFractionInfo_HowToRecycle;
        if (!string.IsNullOrWhiteSpace(howToRecycleString))
        {
          yield return howToRecycleString;
        }
      }
    }

    public LampFractionInfo(Guid id)
    {
      Debug.Assert(id != null, $"Id for {GetType().Name} is null");
      Id = id;
    }
  }
}
