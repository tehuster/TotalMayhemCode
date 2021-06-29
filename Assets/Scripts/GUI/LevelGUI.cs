using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelGUI : MonoBehaviour
{
    public TMP_Text EnemiesText;
    public LevelScriptable levelStats;

    private void Update()
    {
        EnemiesText.text = $"{levelStats.totalEnemies - levelStats.enemiesGo.Count} / {levelStats.totalEnemies}";
    }
}
