using System;
using System.Collections.Generic;
using System.Diagnostics;
using RecyclingBot.Properties;

namespace RecyclingBot.Control.Handlers.RecyclingCodeRecognition.RecyclingCodeInfo
{
  public class PE_HDRecyclingCodeInfo : IRecyclingCodeInfo
  {
    public Guid Id
    {
      get;
    }

    public string Label => "two_PE-HD";

    public string Name => RecyclingCodeInfoResources.PE_HDRecyclingCode_Name;

    public IEnumerable<string> AllInfo
    {
      get
      {
        string aboutString = RecyclingCodeInfoResources.PE_HDRecyclingCode_About;
        if (!string.IsNullOrWhiteSpace(aboutString))
        {
          yield return aboutString;
        }

        string usesString = RecyclingCodeInfoResources.PE_HDRecyclingCode_Uses;
        if (!string.IsNullOrWhiteSpace(usesString))
        {
          yield return usesString;
        }

        string recyclingInfoString = RecyclingCodeInfoResources.PE_HDRecyclingCode_RecyclingInfo;
        if (!string.IsNullOrWhiteSpace(recyclingInfoString))
        {
          yield return recyclingInfoString;
        }
      }
    }

    public PE_HDRecyclingCodeInfo(Guid id)
    {
      Debug.Assert(id != null, $"Id for {GetType().Name} is null");
      Id = id;
    }
  }
}
