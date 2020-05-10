using System;
using System.Collections.Generic;
using System.Diagnostics;
using RecyclingBot.Properties;

namespace RecyclingBot.Control.Handlers.Wiki.FractionsInfo.Info
{
  public class PlasticFractionInfo : IFractionInfo
  {
    public Guid Id
    {
      get;
    }

    public string Topic => FractionInfoResources.PlasticFractionInfo_Topic;

    public IEnumerable<string> AllInfo
    {
      get
      {
        string whyCollectString = FractionInfoResources.PlasticFractionInfo_WhyCollect;
        if (!string.IsNullOrWhiteSpace(whyCollectString))
        {
          yield return whyCollectString;
        }

        string howToRecycleString = FractionInfoResources.PlasticFractionInfo_HowToRecycle;
        if (!string.IsNullOrWhiteSpace(howToRecycleString))
        {
          yield return howToRecycleString;
        }
      }
    }

    public PlasticFractionInfo(Guid id)
    {
      Debug.Assert(id != null, $"Id for {GetType().Name} is null");
      Id = id;
    }
  }
}
