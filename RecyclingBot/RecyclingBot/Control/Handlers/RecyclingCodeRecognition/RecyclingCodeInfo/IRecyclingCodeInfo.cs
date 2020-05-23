using System;
using System.Collections.Generic;

namespace RecyclingBot.Control.Handlers.RecyclingCodeRecognition.RecyclingCodeInfo
{
  public interface IRecyclingCodeInfo
  {
    Guid Id
    {
      get;
    }

    string Label
    {
      get;
    }

    string Name
    {
      get;
    }

    IEnumerable<string> AllInfo
    {
      get;
    }
  }
}
