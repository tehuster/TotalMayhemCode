using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerScriptable playerStats;

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag != "Enemy")
            return;

        EnemyBase enemy = other.transform.GetComponent<EnemyBase>();
        ReceiveDamage(enemy.Damage);
    }

    private void ReceiveDamage(int damage)
    {
        playerStats.healthPoints -= damage;

        if (playerStats.healthPoints <= 0)
        {
            Debug.Log("Gameover");
        }

    }
}
