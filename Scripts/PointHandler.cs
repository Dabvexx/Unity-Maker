using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PointHandler
{
    static int points = 0;

    public static void CalculatePointsGained(int index)
    {
        int[] PointValues = { 200, 500, 1000, 2000, 4000, 8000, 10000 };
        points += PointValues[index];
    }
}
