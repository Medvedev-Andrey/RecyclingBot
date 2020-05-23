using System;
using System.Collections.Generic;
using System.Diagnostics;
using RecyclingBot.Properties;

namespace RecyclingBot.Control.Handlers.RecyclingCodeRecognition.RecyclingCodeInfo
{
  public class PVCRecyclingCodeInfo : IRecyclingCodeInfo
  {
    public Guid Id
    {
      get;
    }

    public string Label => "three_PVC";

    public string Name => RecyclingCodeInfoResources.PVCRecyclingCode_Name;

    public IEnumerable<string> AllInfo
    {
      get
      {
        string aboutString = RecyclingCodeInfoResources.PVCRecyclingCode_About;
        if (!string.IsNullOrWhiteSpace(aboutString))
        {
          yield return aboutString;
        }

        string usesString = RecyclingCodeInfoResources.PVCRecyclingCode_Uses;
        if (!string.IsNullOrWhiteSpace(usesString))
        {
          yield return usesString;
        }

        string recyclingInfoString = RecyclingCodeInfoResources.PVCRecyclingCode_RecyclingInfo;
        if (!string.IsNullOrWhiteSpace(recyclingInfoString))
        {
          yield return recyclingInfoString;
        }
      }
    }

    public PVCRecyclingCodeInfo(Guid id)
    {
      Debug.Assert(id != null, $"Id for {GetType().Name} is null");
      Id = id;
    }
  }
}
