using UnityEngine;
using UnityEngine.UI;

public class IconItem : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private Text _value;

    public void SetData(Sprite icon, int value)
    {
        _icon.sprite = icon;
        _value.text = value.ToString();
    }
}
