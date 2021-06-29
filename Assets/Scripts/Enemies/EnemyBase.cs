using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    public EnemyManager enemyManager;
    [SerializeField] protected int healthPoints;
    [SerializeField] private int damage;
    public int Damage
    {
        get { return damage; }
    }

    protected bool activated = false;

    public abstract void Activate();
}
