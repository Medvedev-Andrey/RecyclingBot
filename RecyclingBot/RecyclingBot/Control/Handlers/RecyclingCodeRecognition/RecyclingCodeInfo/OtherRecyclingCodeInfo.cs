using System;
using System.Collections.Generic;
using System.Diagnostics;
using RecyclingBot.Properties;

namespace RecyclingBot.Control.Handlers.RecyclingCodeRecognition.RecyclingCodeInfo
{
  public class OtherRecyclingCodeInfo : IRecyclingCodeInfo
  {
    public Guid Id
    {
      get;
    }

    public string Label => "seven_other";

    public string Name => RecyclingCodeInfoResources.OtherRecyclingCode_Name;

    public IEnumerable<string> AllInfo
    {
      get
      {
        string aboutString = RecyclingCodeInfoResources.OtherRecyclingCode_About;
        if (!string.IsNullOrWhiteSpace(aboutString))
        {
          yield return aboutString;
        }

        string usesString = RecyclingCodeInfoResources.OtherRecyclingCode_Uses;
        if (!string.IsNullOrWhiteSpace(usesString))
        {
          yield return usesString;
        }

        string recyclingInfoString = RecyclingCodeInfoResources.OtherRecyclingCode_RecyclingInfo;
        if (!string.IsNullOrWhiteSpace(recyclingInfoString))
        {
          yield return recyclingInfoString;
        }
      }
    }

    public OtherRecyclingCodeInfo(Guid id)
    {
      Debug.Assert(id != null, $"Id for {GetType().Name} is null");
      Id = id;
    }
  }
}
