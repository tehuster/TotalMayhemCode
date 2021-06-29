using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelGUI : MonoBehaviour
{
    [SerializeField] private TMP_Text EnemiesText;
    [SerializeField] private LevelScriptable levelStats;

    private void Update()
    {
        EnemiesText.text = $"{levelStats.totalEnemies - levelStats.enemiesGo.Count} / {levelStats.totalEnemies}";
    }
}
