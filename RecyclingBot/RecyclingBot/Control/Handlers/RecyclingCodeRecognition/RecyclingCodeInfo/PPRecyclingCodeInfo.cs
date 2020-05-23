using System;
using System.Collections.Generic;
using System.Diagnostics;
using RecyclingBot.Properties;

namespace RecyclingBot.Control.Handlers.RecyclingCodeRecognition.RecyclingCodeInfo
{
  public class PPRecyclingCodeInfo : IRecyclingCodeInfo
  {
    public Guid Id
    {
      get;
    }

    public string Label => "five_PP";

    public string Name => RecyclingCodeInfoResources.PPRecyclingCode_Name;

    public IEnumerable<string> AllInfo
    {
      get
      {
        string aboutString = RecyclingCodeInfoResources.PPRecyclingCode_About;
        if (!string.IsNullOrWhiteSpace(aboutString))
        {
          yield return aboutString;
        }

        string usesString = RecyclingCodeInfoResources.PPRecyclingCode_Uses;
        if (!string.IsNullOrWhiteSpace(usesString))
        {
          yield return usesString;
        }

        string recyclingInfoString = RecyclingCodeInfoResources.PPRecyclingCode_RecyclingInfo;
        if (!string.IsNullOrWhiteSpace(recyclingInfoString))
        {
          yield return recyclingInfoString;
        }
      }
    }

    public PPRecyclingCodeInfo(Guid id)
    {
      Debug.Assert(id != null, $"Id for {GetType().Name} is null");
      Id = id;
    }
  }
}
