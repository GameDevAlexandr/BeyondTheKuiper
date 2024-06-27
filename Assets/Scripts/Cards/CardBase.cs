using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBase : MonoBehaviour
{
    public CardItem[] cards => InitCerd();
    private CardItem[] _cards;
    private CardItem[] InitCerd()
    {
        if (_cards == null)
        {
            var c = Resources.LoadAll<CardItem>("Cards");
            _cards = new CardItem[c.Length];
            for (int i = 0; i < c.Length; i++)
            {
                _cards[c[i].index] = c[i];
            }
        }
        return _cards;
    }
}
