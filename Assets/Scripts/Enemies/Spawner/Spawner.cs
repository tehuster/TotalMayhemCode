using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    public abstract Vector3 CalculatePosition(float degree, float scale, int amount);
}
