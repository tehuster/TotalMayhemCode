using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class ProjectileBase : MonoBehaviour
{
    [SerializeField] protected int damage;
    public int Damage
    {
        get { return damage; }
    }
    [SerializeField] protected float lifeTime;
    protected Rigidbody rBody;
}
