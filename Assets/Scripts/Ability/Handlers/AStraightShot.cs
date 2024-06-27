using UnityEngine;
public class AStraightShot: MonoBehaviour, IAbility
{
    public SpaceManager maneger { get; set; }

    public void Activate(SpaceCell cell, int count) { }
    public void Move(bool isUp) { }
    public void Remove() { }
    public void Use(int line, int value)
    {
        for (int i = 0; i < maneger.cellMatrix.GetLength(0); i++)
        {
            var m = maneger.cellMatrix[i, line].meteorite;
            if (m != null)
            {
                m.TakeDamage(value);
                break;
            }
        }
    }

    public void UseCard(CardItem card) { }
}
