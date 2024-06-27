using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static DataCalculation;
using static GameData;

public class SpaceManager : MonoBehaviour
{
    [HideInInspector] public UnityEvent nextStep = new UnityEvent();
    [HideInInspector] public List<MeteoriteObject> meteorites  = new List<MeteoriteObject>();
    [HideInInspector] public SpaceCell[,] cellMatrix;

    [SerializeField] private SpaceCell[] _cells;
    [SerializeField] private MeteoriteBase _mBase;    

    private List<int> _mSteps = new List<int>();
    
    private int _stepBetween;
    private int _curMeteorIndex;
    public void CreateRound(int round)
    {
        stepNumber = 0;
        _stepBetween = 0;
        var trail = StepsInRound(round);
        var med = StepsInRound(round) / meteorites.Count + 2;
        List<int> ms = new List<int>();
        int health = HealthInRound(round);
        while (health > 0)
        {
            var m = _mBase.items[Random.Range(0, _mBase.items.Length)];
            var mo = Instantiate(m.mObject);
            mo.gameObject.SetActive(false);
            mo.manager = this;
            nextStep.AddListener(mo.Action);
            meteorites.Add(mo);
            var hp = MeteoriteHealth(m.level, round);
            mo.TakeDamage(-hp);
            mo.speed = 1;
            health -= hp;
            var rnd = Random.Range(0, med);
            trail = Mathf.Max(0, trail - rnd);
            if (health <= 0)
            {
                rnd = trail;
            }
            ms.Add(rnd);
        }
        var cnt = ms.Count;
        for (int i = 0; i < cnt; i++)
        {
            var r = Random.Range(0, ms.Count);
            _mSteps.Add(ms[r]);
            ms.RemoveAt(r);
        }
    }
    private SpaceCell[,] CreatePlace()
    {
        if (cellMatrix == null)
        {
            cellMatrix = new SpaceCell[12, 5];
            for (int i = 0; i < _cells.Length; i++)
            {
                _cells[i].pisiton = new Vector2Int(i % 12, i / 12);
                cellMatrix[i % 12, i / 12] = _cells[i];
            }
        }
        return cellMatrix;
    }

    private void ShowMeteorite()
    {
        if (_stepBetween <= 0)
        {
            List<int> c = new List<int> { 0, 1, 2, 3, 4 };
            SpaceCell resC = null;
            while (true)
            {
                var idx = Random.Range(0, c.Count);
                resC = CreatePlace()[cellMatrix.GetLength(0) - 1, idx];
                if (resC.meteorite == null)
                {
                    break;
                }
                if (c.Count == 0)
                {
                    _stepBetween = 1;
                    return;
                }
                c.RemoveAt(idx);                
            }
            meteorites[_curMeteorIndex].Show(resC);
            _stepBetween = _mSteps[_curMeteorIndex];
            ShowMeteorite();
        }
    }
    public void NextStep()
    {
        nextStep.Invoke();
        _stepBetween--;
        ShowMeteorite();
    }
}
