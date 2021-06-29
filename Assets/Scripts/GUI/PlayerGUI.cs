using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerGUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TMP_Text HealthPointsText;
    [SerializeField] private PlayerScriptable playerStats;

    private void Update()
    {
        HealthPointsText.text = $"{playerStats.HealthPoints} / 100";
    }
}
