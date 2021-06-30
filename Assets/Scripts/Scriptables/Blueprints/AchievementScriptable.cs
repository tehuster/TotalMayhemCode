using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



[CreateAssetMenu(fileName = "AchievementScriptable", menuName = "Scriptables/Achievement", order = 0)]
public class AchievementScriptable : ScriptableObject
{
    public string tag;
    public Texture2D image;
    public bool achieved = false;
    [SerializeField] private string Description;
}
