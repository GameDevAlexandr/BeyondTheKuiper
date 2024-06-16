using UnityEngine;

public class DataCalculation : MonoBehaviour
{
    public static int MeteoriteHealth(int meteoriteLvl, int round)
    {
        return 10 + 3 * meteoriteLvl + 3 * round;
    }
}
