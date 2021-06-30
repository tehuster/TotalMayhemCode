using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreGUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TMP_Text ScoreText;
    [SerializeField] private ScoreScriptable scoreStats;

    private void Update()
    {
        ScoreText.text = $"{scoreStats.score} points!!";
    }
}
