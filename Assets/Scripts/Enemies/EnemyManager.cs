using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerScriptable playerStats;
    public LevelScriptable levelStats;
    public List<GameObject> enemiesGO;

    private void Start()
    {
        levelStats.enemiesGo = enemiesGO;
        levelStats.totalEnemies = enemiesGO.Count;
    }
}
