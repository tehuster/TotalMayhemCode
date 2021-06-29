using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerGUI : MonoBehaviour
{
    public TMP_Text HealthPointsText;
    public PlayerScriptable playerStats;

    private void Update()
    {
        HealthPointsText.text = $"{playerStats.HealthPoints} / 100";
    }
}
