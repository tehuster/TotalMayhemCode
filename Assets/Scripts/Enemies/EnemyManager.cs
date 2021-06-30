using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;

public class EnemyManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float spawnTime;

    [Header("Event")]
    public UnityEvent<int> OnEnemyDied;

    [Header("References")]
    public PlayerScriptable playerStats;
    [HideInInspector] public List<GameObject> enemiesGO;
    [SerializeField] private GameObject basicEnemy;
    [SerializeField] private SpawnerScriptable[] spawners;
    [SerializeField] private List<Transform> spawningPositions;
    [SerializeField] private CinemachineTargetGroup targetGroup;

    private int level = 1;

    private void Start()
    {
        StartCoroutine(SpawnEnemies(level * 10, spawnTime));
    }

    private IEnumerator SpawnEnemies(int amount, float waitTime)
    {
        int rPos = Random.Range(0, spawningPositions.Count);
        Transform randomSpawnpoint = spawningPositions[rPos];
        int rSpawn = Random.Range(0, spawners.Length);
        Vector3[] enemyPositions = spawners[rSpawn].GetSpawnPositions(randomSpawnpoint.position, amount);

        targetGroup.AddMember(randomSpawnpoint, 1, 2);

        foreach (Vector3 enemyPosition in enemyPositions)
        {
            //Replacing with ObjectPooling
            GameObject newEnemy = Instantiate(basicEnemy, enemyPosition, Quaternion.identity, this.transform);
            newEnemy.GetComponent<EnemyBase>().enemyManager = this;
            enemiesGO.Add(newEnemy);
            yield return new WaitForSeconds(waitTime);
        }
        yield return new WaitForSeconds(1f);
        foreach (GameObject enemy in enemiesGO)
        {
            enemy.GetComponent<EnemyBase>().Activate();
        }
        yield return new WaitForSeconds(2f);
        targetGroup.RemoveMember(randomSpawnpoint);
    }

    public void ResetManager()
    {
        foreach (GameObject enemy in enemiesGO)
        {
            Destroy(enemy);
        }
        enemiesGO.Clear();
        level = 1;
        StartCoroutine(SpawnEnemies(level * 10, spawnTime));
    }

    public void OnEnemyDeath(GameObject enemy, int points)
    {
        enemiesGO.Remove(enemy);
        OnEnemyDied?.Invoke(points);

        if (enemiesGO.Count == 0)
        {
            level++;
            StartCoroutine(SpawnEnemies(level * 10, spawnTime));
        }
    }
}
