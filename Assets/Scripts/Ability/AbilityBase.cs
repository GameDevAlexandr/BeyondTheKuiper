using System.Collections.Generic;
using UnityEngine;
using static EnumData;

public class AbilityBase : MonoBehaviour
{    
    public Dictionary<AbilityType, AbilityItem> abilityForType=>InitAbilityBase();
    private Dictionary<AbilityType, AbilityItem> _abilityForType;
    private Dictionary<AbilityType, AbilityItem> InitAbilityBase()
    {

        if (_abilityForType == null)
        {
            var abils = Resources.LoadAll<AbilityItem>("Ability");
            _abilityForType = new Dictionary<AbilityType, AbilityItem>();
            for (int i = 0; i < abils.Length; i++)
            {
                _abilityForType.Add(abils[i].type, abils[i]);
            }
        }
        return _abilityForType;
    }
}
