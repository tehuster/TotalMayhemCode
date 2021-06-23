using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Companion_A : CompanionBase
{
    [Header("Settings")]
    public float targetingRange;
    public float cooldownTimer;

    [Header("References")]
    public EnemyManager enemyManager;
    public GameObject bullet;


    private bool isCoolingDown = false;

    private void Update()
    {
        float closestEnemy = float.MaxValue;
        GameObject targetEnemy = null;
        foreach (GameObject enemy in enemyManager.EnemiesGO)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < closestEnemy)
            {
                closestEnemy = distance;
                targetEnemy = enemy;
            }
        }

        if (closestEnemy < targetingRange)
            Shoot(targetEnemy);
    }

    private void Shoot(GameObject target)
    {
        if (isCoolingDown)
            return;

        GameObject projectile = Instantiate(bullet, transform.position, bullet.transform.rotation);

        Vector3 direction = (target.transform.position - transform.position).normalized;
        projectile.transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
        projectile.GetComponent<Rigidbody>().AddForce(direction * 300);

        StartCoroutine(Reloading());
    }

    private IEnumerator Reloading()
    {
        isCoolingDown = true;
        yield return new WaitForSeconds(cooldownTimer);
        isCoolingDown = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, targetingRange);
    }
}
