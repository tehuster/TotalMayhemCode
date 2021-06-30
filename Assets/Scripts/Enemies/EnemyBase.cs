using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [Header("BaseSettings")]
    [SerializeField] protected int healthPoints;
    [SerializeField] private int damage;
    [SerializeField] protected int points;
    [HideInInspector] public EnemyManager enemyManager;
    public int Damage
    {
        get { return damage; }
    }
    protected bool activated = false;
    public abstract void Activate();
}
