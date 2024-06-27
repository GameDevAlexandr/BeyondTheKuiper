using UnityEngine;
using System.Collections.Generic;
using static GameData;

public class CardsManager : MonoBehaviour
{
    [SerializeField] private CardBase _base;
    private void Awake()
    {
        if(cards == null)
        {
            cards = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                cards.Add(0);
            }
        }
    }

    private void GetNewCard()
    {

    }
}
