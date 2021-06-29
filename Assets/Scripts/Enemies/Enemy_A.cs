using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]
public class Enemy_A : EnemyBase
{
    [SerializeField] private float moveSpeed;
    [ColorUsage(true, true)] public Color glowColor;

    private Rigidbody rBody;
    private Renderer render;

    private void Awake()
    {
        rBody = GetComponent<Rigidbody>();
        render = GetComponent<Renderer>();
    }

    private void Start()
    {
        render.material.EnableKeyword("_EMISSION");
    }

    private void FixedUpdate()
    {
        if (!activated)
            return;

        Vector3 direction = (enemyManager.playerStats.currentPosition - transform.position).normalized;
        rBody.velocity = direction * moveSpeed;
    }

    public override void Activate()
    {
        render.material.SetColor("_EmissionColor", glowColor); //Add optimalisation by caching "_EmissionColor"
        activated = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag != "Projectile")
            return;

        ProjectileBase projectile = other.transform.GetComponent<ProjectileBase>();

        receiveDamage(projectile.Damage);
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
