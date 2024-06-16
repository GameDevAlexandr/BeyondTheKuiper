using UnityEngine;


public class SpaceCell : MonoBehaviour
{
    [HideInInspector] public MeteoriteObject meteorite;
    [HideInInspector] public Vector2Int pisiton; 
    [SerializeField] private AbilityPlace _abilities;

    public void Action()
    {
        _abilities.Action(this);
    }
    
    public void SetMeteorite(MeteoriteObject meteorite)
    {        
        meteorite.currentCell.RemoveMeteorite();
        if (this.meteorite != null)
        {
            Collision(meteorite);
            return;
        }
        meteorite.transform.position = transform.position;
        this.meteorite = meteorite; 

    }
    public void RemoveMeteorite()
    {
        meteorite = null;
    }
    private void Collision(MeteoriteObject meteorite)
    {
        
        int h = meteorite.health;
        meteorite.TakeDamage(this.meteorite.health);
        this.meteorite.TakeDamage(h);
        if (meteorite.health > 0)
        {
            SetMeteorite(meteorite);
        }         
    }
}
