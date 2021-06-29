using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : ProjectileBase
{
    private void Start()
    {
        rBody = GetComponent<Rigidbody>();
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}
