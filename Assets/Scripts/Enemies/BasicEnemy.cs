using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : BaseEnemy
{
    public EnemyManager enemyManager;
    public float moveSpeed;

    private Rigidbody rBody;

    private void Awake()
    {
        rBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 direction = (enemyManager.playerStats.currentPosition - transform.position).normalized;
        rBody.AddForce(direction * moveSpeed);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag != "Projectile")
            return;

        ProjectileBase projectile = other.transform.GetComponent<ProjectileBase>();

        receiveDamage(projectile.damage);
    }

    private void receiveDamage(int damage)
    {
        healthPoints -= damage;

        if (healthPoints <= 0)
        {
            enemyManager.enemiesGO.Remove(this.gameObject);
            Destroy(gameObject);
        }

    }
}
