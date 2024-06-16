
using System;
using UnityEngine;
using UnityEngine.UI;

public class StructData
{
    [Serializable]
    public struct AbilityData
    {
       public AbilityItem item;
       public int count;
    }

    [Serializable]

    public struct IconData
    {
        public Image icon;
        public Text value;
    }
}
