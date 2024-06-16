using UnityEngine;
using UnityEngine.UI;

public class MeteoriteObject : MonoBehaviour
{
    [HideInInspector] public SpaceCell currentCell;   

    [SerializeField] private Text _health;
    [SerializeField] private int _size;
    [SerializeField] private AbilityPlace _abilities;   

    private int _maxHealth;
    private int _currentHealth;
    public int health => _currentHealth;
    public void Show(int health)
    {
        _currentHealth = health;
        _maxHealth = health;
        SetHealthUI();
    }
    public int TakeDamage(int damage)
    {
        int val = _currentHealth - damage;

        if (val <= 0)
        {
            Destroy();            
        }
        else
        {
            _currentHealth = val;
            SetHealthUI();
        }

        return val;
    }
    public void Destroy()
    {
        currentCell.RemoveMeteorite();
    }
    private void SetHealthUI()
    {
        _health.text = _currentHealth + "/" + _maxHealth;
    }
    public void Action()
    {
        _abilities.Action(currentCell);
    }
}
