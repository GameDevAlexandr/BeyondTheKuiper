using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float value { get => _value; set => SetValue(value);}

    [SerializeField] private RectTransform _healthRect;
    [SerializeField] private RectTransform _damageRect;
    [SerializeField] private bool _isVertical;
    [SerializeField] private float _filledSpeed;
    [SerializeField] private Text _valueText;

    private float _value = 1;
    private float _damageValue = 1;


    private void SetValue(float value)
    {
        value = Mathf.Clamp01(value);
        if (_value < value)
        {
            _damageValue = value;
            SetNewRectPosition(_damageRect, _damageValue - value);
        }
        _value = value;
        SetNewRectPosition(_healthRect, _value - value);

    }

    public void SetValue(float current, float max)
    {
        SetValue(current / max);
        _valueText.text = current + "/" + max;
    }
    private void Update()
    {
        if (_damageValue > _value)
        {
            float det = Mathf.Max(_value, _damageValue - Time.deltaTime * _filledSpeed);
            SetNewRectPosition(_damageRect, _damageValue - det);
            _damageValue = det;
        }
    }

    private void SetNewRectPosition(RectTransform r, float value)
    {
        float x = _isVertical ? r.position.x : r.position.x - r.rect.width * value;
        float y = _isVertical ? r.position.y - r.rect.height * value : r.position.y;
        r.position = new Vector2(x, y);
    }
    public void Damage(float shift)
    {
        value -= shift;
    }
}
