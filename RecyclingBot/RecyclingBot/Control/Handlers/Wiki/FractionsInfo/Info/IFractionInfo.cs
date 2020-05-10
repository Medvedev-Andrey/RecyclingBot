using System;
using System.Collections.Generic;

namespace RecyclingBot.Control.Handlers.Wiki.FractionsInfo.Info
{
  public interface IFractionInfo
  {
    Guid Id
    {
      get;
    }

    string Topic
    {
      get;
    }

    IEnumerable<string> AllInfo
    {
      get;
    }
  }
}
