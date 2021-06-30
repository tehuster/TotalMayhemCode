using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementUI : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float AchievementPopupTime;
    [Header("UI References")]
    [SerializeField] private GameObject panelUI;
    [SerializeField] private TMP_Text AchievementText;
    [SerializeField] private RawImage AchievementImage;

    public void ShowAchievement(AchievementScriptable achievement)
    {
        StartCoroutine(ShowAchievementUI(achievement));
    }

    private IEnumerator ShowAchievementUI(AchievementScriptable achievement)
    {
        panelUI.SetActive(true);
        AchievementText.text = achievement.tag;
        AchievementImage.texture = achievement.image;
        yield return new WaitForSeconds(AchievementPopupTime);
        panelUI.SetActive(false);
    }
}
