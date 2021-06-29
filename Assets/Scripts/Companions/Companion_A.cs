using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Companion_A : CompanionBase
{
    [Header("Settings")]
    [SerializeField] private float targetingRange;
    [SerializeField] private float cooldownTimer;


    [Header("References")]
    public EnemyManager enemyManager;
    public GameObject bullet;
    public GameObject turret;
    public Transform barrel;


    private bool isCoolingDown = false;

    private void Update()
    {
        Targeting();
    }

    private void Targeting()
    {
        float closestEnemy = float.MaxValue;
        GameObject targetEnemy = null;

        foreach (GameObject enemy in enemyManager.enemiesGO)
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



        GameObject projectile = Instantiate(bullet, barrel.position, bullet.transform.rotation);

        Vector3 direction = (target.transform.position - transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        turret.transform.rotation = rotation;
        projectile.transform.rotation = rotation;
        projectile.GetComponent<Rigidbody>().AddForce(direction * 600);

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
