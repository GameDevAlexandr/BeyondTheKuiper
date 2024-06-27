using System.Collections.Generic;
using UnityEngine;

public static class MyString 
{
    private static Dictionary<string, string>  colors;
   public static string ColorText(string text, string colorId)
    {
        ColorInit();
        var result = "<color=#" + colors[colorId] + ">" + text + "</color>";
        return  result;
    }

    private static void ColorInit()
    {
        if (colors == null)
        {
            var col = Resources.LoadAll<ColorCode>("System/Colors");
            colors = new Dictionary<string, string>();
            for (int i = 0; i < col.Length; i++)
            {
                colors.Add(col[i].id, col[i].colorCode);
            }
        }
    }
    public static string SetColorText(string res)
    {
        while (true)
        {
            int sIdx = res.IndexOf("color_");
            if (sIdx == -1)
            {
                return res;
            }
            int eIdx = res.IndexOf(" ", sIdx);
            int eWord = res.IndexOf(" ", eIdx + 1);
            if (eWord == -1)
            {
                eWord = res.Length;
            }
            string colIdx = res.Substring(sIdx + 1, eIdx - sIdx - 1);
            string word = res.Substring(eIdx + 1, eWord - eIdx - 1);
            res = res.Remove(sIdx, eWord - sIdx);
            res = res.Insert(sIdx, ColorText(word, colIdx));
        }
    }
    public static string SetValueText(string[] value, string res)
    {
        while (true)
        {
            int sIdx = res.IndexOf("value_");
            if (sIdx == -1)
            {
                return res;
            }
            int eIdx = res.IndexOf("_", sIdx - 1);
            string v = res.Substring(eIdx + 1, 1);
            res = res.Replace("value_" + v, value[int.Parse(v)]);
        }
        return res;
    }
}
