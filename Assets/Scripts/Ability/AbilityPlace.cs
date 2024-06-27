using System.Collections.Generic;
using UnityEngine;

public class AbilityPlace : MonoBehaviour
{
    public Dictionary<AbilityItem, int> _abilities;
    [SerializeField] private IconItem[] _abilitiesIcon;

    public void Action(SpaceCell cell)
    {
        foreach (var a in _abilities)
        {
            a.Key.handler.Activate(cell, a.Value);
        }
    }
    public void AddAbility(AbilityItem item, int count)
    {
        if (_abilities.ContainsKey(item))
        {
            _abilities[item] += count;
        }
        else
        {
            _abilities.Add(item, count);
        }
        int counter = 0;
        for (int i = 0; i < _abilitiesIcon.Length; i++)
        {
            _abilitiesIcon[i].gameObject.SetActive(false);
        }
        foreach (var a in _abilities)
        {
            if (counter < _abilitiesIcon.Length)
            {
                _abilitiesIcon[counter].SetData(a.Key.icon, a.Value);
            }
            counter++;
        }
    }
}
