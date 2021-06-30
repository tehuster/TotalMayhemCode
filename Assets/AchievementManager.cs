using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{

    public AchievementUI achievementUI;
    public AchievementScriptable[] Achievements;
    private Dictionary<string, AchievementScriptable> AchievementsByTag;
    private int enemyDeathCounter = 0;

    private void Awake()
    {
        AchievementsByTag = new Dictionary<string, AchievementScriptable>();
        foreach (AchievementScriptable achievement in Achievements)
        {
            AchievementsByTag.Add(achievement.tag, achievement);
        }
    }

    public void OnEnemyDeath()
    {
        enemyDeathCounter++;
        if (enemyDeathCounter == 5 && !AchievementsByTag["Killer"].achieved)
        {
            AchievementsByTag["Killer"].achieved = true;
            achievementUI.ShowAchievement(AchievementsByTag["Killer"]);
        }

        if (enemyDeathCounter == 10 && !AchievementsByTag["StoneColdKiller"].achieved)
        {
            AchievementsByTag["StoneColdKiller"].achieved = true;
            achievementUI.ShowAchievement(AchievementsByTag["StoneColdKiller"]);
        }

        if (enemyDeathCounter == 50 && !AchievementsByTag["Interchange Killa"].achieved)
        {
            AchievementsByTag["Interchange Killa"].achieved = true;
            achievementUI.ShowAchievement(AchievementsByTag["Interchange Killa"]);
        }
    }
}
