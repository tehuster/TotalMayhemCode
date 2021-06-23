using UnityEngine;


[CreateAssetMenu(fileName = "InputScriptable", menuName = "Scriptables/Input", order = 0)]
public class InputScriptable : ScriptableObject
{
    public Vector3 mousePosition;
    public float horizontal;
    public float vertical;
    public bool dodge;
    public bool boost;
}
