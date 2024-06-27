using UnityEngine;
using NaughtyAttributes;
using static StructData;

[CreateAssetMenu(fileName = "NewCard", menuName ="MyGame/Card/Card", order = 0)]
public class CardItem : ScriptableObject
{
    [SerializeField] private int _index;
    [SerializeField] private int _rare;
    [SerializeField] private string _nameID;
    [SerializeField] private string _descriptionID;
    [ShowAssetPreview] [SerializeField] private Sprite _icon;
    [SerializeField] AbilityData[] _abilities;

    public int index => _index;
    public int rare => _rare;
    public string nameID => _nameID;
    public string descriptionID => _descriptionID;
    public Sprite icon => _icon;
    public AbilityData[] abilities => _abilities;
}
