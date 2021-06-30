using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerScriptable", menuName = "Scriptables/PlayerScriptable", order = 0)]
public class PlayerScriptable : ScriptableObject
{
    public Vector3 currentPosition;
    public int healthPoints;
    [SerializeField] int startingHealthPoints;

    public void ResetPlayer()
    {
        healthPoints = startingHealthPoints;
    }
}