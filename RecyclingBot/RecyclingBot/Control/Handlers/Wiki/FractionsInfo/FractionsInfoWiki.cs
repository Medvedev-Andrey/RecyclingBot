using System;
using System.Collections.Generic;
using System.Linq;
using RecyclingBot.Control.Handlers.Wiki.FractionsInfo.Info;

namespace RecyclingBot.Control.Handlers.Wiki.FractionsInfo
{
  public static class FractionsInfoWiki
  {
    public static List<IFractionInfo> Available = new List<IFractionInfo>()
    {
      new GlassFractionInfo(typeof(GlassFractionInfo).GUID),
      new LampFractionInfo(typeof(LampFractionInfo).GUID),
      new PlasticFractionInfo(typeof(PlasticFractionInfo).GUID),
      new MetalFractionInfo(typeof(MetalFractionInfo).GUID),
      new PaperFractionInfo(typeof(PaperFractionInfo).GUID)
    };

    public static Dictionary<Guid, IFractionInfo> IdToFractionInfo = Available.ToDictionary(fractionInfo => fractionInfo.Id, fractionInfo => fractionInfo);
  }
}
