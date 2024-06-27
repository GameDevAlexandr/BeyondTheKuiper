using UnityEngine;

public class DataCalculation : MonoBehaviour
{
    public static int MeteoriteHealth(int meteoriteLvl, int round)
    {
        return 10 + 3 * meteoriteLvl + 3 * round;
    }

    public static int HealthInRound(int round)
    {
        return 200 + 50 * round;
    }
    public static int StepsInRound(int round)
    {
        return 20 + round * 2;
    }
}
