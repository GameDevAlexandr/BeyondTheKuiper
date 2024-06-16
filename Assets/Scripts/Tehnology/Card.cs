using UnityEngine;
using NaughtyAttributes;
using static StructData;

[CreateAssetMenu(fileName = "NewCard", menuName ="MyGame/Card", order = 0)]
public class Card : ScriptableObject
{
    [SerializeField] private string _nameID;
    [ShowAssetPreview] [SerializeField] private Sprite _icon;
    [SerializeField] AbilityData[] _abilities;

    public string nameID => _nameID;
    public Sprite icon => _icon;
    public AbilityData[] abilities => _abilities;
}
