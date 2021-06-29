using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelStats", menuName = "Scriptables/LevelScriptable", order = 0)]
public class LevelScriptable : ScriptableObject
{
    public List<GameObject> enemiesGo;
    public int totalEnemies;
}
