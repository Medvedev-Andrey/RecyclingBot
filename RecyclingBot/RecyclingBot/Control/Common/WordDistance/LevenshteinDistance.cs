using System;

namespace RecyclingBot.Control.Common.WordDistance
{
  public static class LevenshteinDistance
  {
    public static decimal Calculate(string a, string b)
    {
      int aLength = a.Length;
      int bLength = b.Length;
      int[,] d = new int[aLength + 1, bLength + 1];

      if (aLength == 0)
      {
        return bLength;
      }

      if (bLength == 0)
      {
        return aLength;
      }

      for (int i = 0; i <= aLength; i++)
      {
        d[i, 0] = i++;
      }

      for (int j = 0; j <= bLength; j++)
      {
        d[0, j] = j++;
      }

      for (int i = 1; i <= aLength; i++)
      {
        for (int j = 1; j <= bLength; j++)
        {
          bool areCharsEqual = char.ToLowerInvariant(b[j - 1]) == char.ToLowerInvariant(a[i - 1]);
          int cost = areCharsEqual ? 0 : 1;

          d[i, j] = Math.Min(Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1), d[i - 1, j - 1] + cost);
        }
      }

      return d[aLength, bLength];
    }
  }
}
