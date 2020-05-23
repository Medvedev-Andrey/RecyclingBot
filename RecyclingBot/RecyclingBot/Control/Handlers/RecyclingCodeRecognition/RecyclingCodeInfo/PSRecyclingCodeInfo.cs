using System;
using System.Collections.Generic;
using System.Diagnostics;
using RecyclingBot.Properties;

namespace RecyclingBot.Control.Handlers.RecyclingCodeRecognition.RecyclingCodeInfo
{
  public class PSRecyclingCodeInfo : IRecyclingCodeInfo
  {
    public Guid Id
    {
      get;
    }

    public string Label => "six_PS";

    public string Name => RecyclingCodeInfoResources.PSRecyclingCode_Name;

    public IEnumerable<string> AllInfo
    {
      get
      {
        string aboutString = RecyclingCodeInfoResources.PSRecyclingCode_About;
        if (!string.IsNullOrWhiteSpace(aboutString))
        {
          yield return aboutString;
        }

        string usesString = RecyclingCodeInfoResources.PSRecyclingCode_Uses;
        if (!string.IsNullOrWhiteSpace(usesString))
        {
          yield return usesString;
        }

        string recyclingInfoString = RecyclingCodeInfoResources.PSRecyclingCode_RecyclingInfo;
        if (!string.IsNullOrWhiteSpace(recyclingInfoString))
        {
          yield return recyclingInfoString;
        }
      }
    }
    public PSRecyclingCodeInfo(Guid id)
    {
      Debug.Assert(id != null, $"Id for {GetType().Name} is null");
      Id = id;
    }
  }
}
