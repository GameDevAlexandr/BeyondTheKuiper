using UnityEngine;

public class MeteoriteBase : MonoBehaviour
{
    public MeteoriteItem[] items => LoadData();
    private MeteoriteItem[] _items;
    private MeteoriteItem[] LoadData()
    {
        if (_items == null)
        {
            _items = Resources.LoadAll<MeteoriteItem>("Enemy");
        }
        return _items;
    }
}
