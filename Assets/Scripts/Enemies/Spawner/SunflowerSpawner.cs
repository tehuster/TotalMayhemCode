using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunflowerSpawner : Spawner
{
    public float degree;
    public float scale;
    public int amount;

    public override Vector3 CalculatePosition(float degree, float scale, int amount)
    {
        double angle = amount * (degree * Mathf.Deg2Rad);
        float r = scale * Mathf.Sqrt(amount);
        float x = r * (float)System.Math.Cos(angle);
        float z = r * (float)System.Math.Sin(angle);
        Vector3 position = new Vector3(x, 0, z);
        return position;
    }
}
