using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerScriptable playerStats;

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag != "Enemy")
            return;

        EnemyBase enemy = other.transform.GetComponent<EnemyBase>();
        receiveDamage(enemy.damage);
    }

    private void receiveDamage(int damage)
    {
        playerStats.HealthPoints -= damage;

        if (playerStats.HealthPoints <= 0)
        {
            Debug.Log("Gameover");
        }

    }
}
