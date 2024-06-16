using UnityEngine;
using NaughtyAttributes;
using static EnumData;

[CreateAssetMenu(fileName = "NewAbility",menuName = "MyGame/Card/Ability", order =1)]
public class AbilityItem : ScriptableObject
{
    [SerializeField] private AbilityType _type;
    [SerializeField] private GameObject _abilityHandler;
    [ShowAssetPreview][SerializeField] private Sprite _icon;
    [SerializeField] private string _nameID;
    [SerializeField] private string _descriptionID;

    private IAbility _handler;
    public GameHandler gameHandler {get; set; }
    public AbilityType type =>_type;
    public Sprite icon => _icon;
    public string nameID => _nameID;
    public string description => _descriptionID;
    public IAbility handler => GetHandler();

    private IAbility GetHandler()
    {
        if (_handler == null)
        {
            _handler = _abilityHandler.GetComponent<IAbility>();
        }
        return _handler;
    }
      
}
