using UnityEngine;

[CreateAssetMenu (fileName = "newMeteorite", menuName ="MyGame/Meteorite", order =0) ]
public class MeteoriteItem : ScriptableObject
{
    [SerializeField] private int _level;
    [SerializeField] private int _size;
    [SerializeField] private MeteoriteObject _object;

    public int level => _level;
    public int size => _size;
    public MeteoriteObject mObject => _object;

}
