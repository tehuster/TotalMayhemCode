using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverGUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TMP_Text ScoreText;
    [SerializeField] private ScoreScriptable scoreStats;

    private void Update()
    {
        ScoreText.text = $"GAMEOVER\n Final Score:{scoreStats.score}\n Press SPACE to restart the game";
    }
}
