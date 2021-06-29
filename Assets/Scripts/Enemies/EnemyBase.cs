using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    public EnemyManager enemyManager;
    public int healthPoints;
    public int damage;

    protected bool activated = false;

    public abstract void Activate();
}
