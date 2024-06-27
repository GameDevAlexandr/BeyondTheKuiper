using Assets.SimpleLocalization.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardObject : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private LocalizedText _nameText;
    [SerializeField] private LocalizedText _descriptionText;
    [SerializeField] private AbilityPlace _abilities;
    [SerializeField] private Button _button;

    private GameHandler _manager;
    private CardItem _card;
    private void Awake()
    {
        _button.onClick.AddListener(UseCard);
    }
    public void SetData(CardItem card, GameHandler handler)
    {
        _manager = handler;
        _card = card;
        _icon.sprite = card.icon;
        _nameText.key = card.nameID;
        _descriptionText.key = card.descriptionID;
    }
    public void UseCard()
    {
        foreach (var item in _card.abilities)
        {
            item.item.handler.Use(_manager.playerPosition, item.count);
        }
    }
    
}
