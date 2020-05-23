using System.Collections.Generic;
using System.Linq;
using RecyclingBot.Control.Handlers.RecyclingCodeRecognition.RecyclingCodeInfo;

namespace RecyclingBot.Control.Handlers.RecyclingCodeRecognition
{
  public static class RecyclingCodeInfoWiki
  {
    public static List<IRecyclingCodeInfo> Available = new List<IRecyclingCodeInfo>()
    {
      new OtherRecyclingCodeInfo(typeof(OtherRecyclingCodeInfo).GUID),
      new PE_HDRecyclingCodeInfo(typeof(PE_HDRecyclingCodeInfo).GUID),
      new PE_LDRecyclingCodeInfo(typeof(PE_LDRecyclingCodeInfo).GUID),
      new PETRecyclingCodeInfo(typeof(PETRecyclingCodeInfo).GUID),
      new PPRecyclingCodeInfo(typeof(PPRecyclingCodeInfo).GUID),
      new PSRecyclingCodeInfo(typeof(PSRecyclingCodeInfo).GUID),
      new PVCRecyclingCodeInfo(typeof(PVCRecyclingCodeInfo).GUID)
    };

    public static Dictionary<string, IRecyclingCodeInfo> LabelToFractionInfo = Available.ToDictionary(fractionInfo => fractionInfo.Label, fractionInfo => fractionInfo);
  }
}
