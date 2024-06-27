using System.Collections.Generic;
using UnityEngine;

public class MeteoriteBase : MonoBehaviour
{
    public MeteoriteItem[] items => LoadData();
    public Dictionary<int, List<MeteoriteItem>> itemForLevel => SetForLevel();
    private MeteoriteItem[] _items;
    private Dictionary<int, List<MeteoriteItem>> _itemForLevel;
    private MeteoriteItem[] LoadData()
    {
        if (_items == null)
        {
            _items = Resources.LoadAll<MeteoriteItem>("Enemy");
        }
        return _items;
    }
    private Dictionary<int, List<MeteoriteItem>> SetForLevel()
    {
        if (_itemForLevel == null)
        {
            _itemForLevel = new Dictionary<int, List<MeteoriteItem>>();
            for (int i = 0; i < items.Length; i++)
            {
                if (!_itemForLevel.ContainsKey(items[i].level))
                {                    
                    _itemForLevel.Add(items[i].level, new List<MeteoriteItem>());
                }
                _itemForLevel[items[i].level].Add(items[i]);
            }            
        }
        return _itemForLevel;
    }
}
