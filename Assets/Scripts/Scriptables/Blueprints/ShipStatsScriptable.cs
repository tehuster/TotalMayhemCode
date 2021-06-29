using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShipStats", menuName = "Scriptables/ShipStatistics", order = 0)]
public class ShipStatsScriptable : ScriptableObject
{
    public float turnSpeed;
    public float speed;
    public float strafeSpeed;
}
