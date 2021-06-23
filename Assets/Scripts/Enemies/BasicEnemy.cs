using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : BaseEnemy
{
    public EnemyManager enemyManager;

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag != "Projectile")
            return;

        ProjectileBase projectile = other.transform.GetComponent<ProjectileBase>();

        receiveDamage(projectile.damage);
    }

    private void receiveDamage(int damage)
    {
        Debug.Log($"{damage} received!");
        healthPoints -= damage;

        if (healthPoints <= 0)
        {
            enemyManager.EnemiesGO.Remove(this.gameObject);
            Destroy(gameObject);
        }

    }
}
