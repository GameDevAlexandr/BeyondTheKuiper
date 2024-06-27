using UnityEngine;
using UnityEngine.UI;

public class MeteoriteObject : MonoBehaviour
{
    [HideInInspector] public SpaceManager manager;
    [HideInInspector] public SpaceCell currentCell;
    [HideInInspector] public int speed;

    [SerializeField] private HealthBar _hpBar;
    [SerializeField] private int _size;
    [SerializeField] private AbilityPlace _abilities;   

    private int _maxHealth;
    private int _currentHealth;
    public int health => _currentHealth;
    public void Show(SpaceCell cell)
    {
        currentCell = cell;
        transform.position = currentCell.transform.position;
        _currentHealth = health;
        _maxHealth = health;
        cell.meteorite = this;
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
         _hpBar.SetValue(_currentHealth,  _maxHealth);
    }
    public void Action()
    {
        _abilities.Action(currentCell);

    }
}
