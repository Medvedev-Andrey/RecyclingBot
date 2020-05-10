using System;
using System.Collections.Generic;
using System.Diagnostics;
using RecyclingBot.Properties;

namespace RecyclingBot.Control.Handlers.Wiki.FractionsInfo.Info
{
  public class GlassFractionInfo : IFractionInfo
  {
    public Guid Id
    {
      get;
    }

    public string Topic => FractionInfoResources.GlassFractionInfo_Topic;

    public IEnumerable<string> AllInfo
    {
      get
      {
        string whyCollectString = FractionInfoResources.GlassFractionInfo_WhyCollect;
        if (!string.IsNullOrWhiteSpace(whyCollectString))
        {
          yield return whyCollectString;
        }

        string whatCanBeRecycledString = FractionInfoResources.GlassFractionInfo_WhatCanBeRecycled;
        if (!string.IsNullOrWhiteSpace(whatCanBeRecycledString))
        {
          yield return whatCanBeRecycledString;
        }

        string howToRecycleString = FractionInfoResources.GlassFractionInfo_HowToRecycle;
        if (!string.IsNullOrWhiteSpace(howToRecycleString))
        {
          yield return howToRecycleString;
        }
      }
    }

    public GlassFractionInfo(Guid id)
    {
      Debug.Assert(id != null, $"Id for {GetType().Name} is null");
      Id = id;
    }
  }
}
