using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class EnemyManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int EnemyAmount;

    [Header("References")]
    public List<GameObject> enemiesGO;
    public PlayerScriptable playerStats;
    [SerializeField] private GameObject basicEnemy;
    [SerializeField] private SpawnerScriptable[] spawners;
    [SerializeField] private CinemachineTargetGroup targetGroup;
    [SerializeField] private List<Transform> spawningPositions;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(SpawnEnemies(0.05f));
        }
    }

    private IEnumerator SpawnEnemies(float waitTime)
    {
        int rPos = Random.Range(0, spawningPositions.Count);
        Transform randomSpawnpoint = spawningPositions[rPos];
        int rSpawn = Random.Range(0, spawners.Length);
        Vector3[] enemyPositions = spawners[rSpawn].GetSpawnPositions(randomSpawnpoint.position, EnemyAmount);

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

    public void RemoveAllEnemies()
    {
        foreach (GameObject enemy in enemiesGO)
        {
            Destroy(enemy);
        }
        enemiesGO.Clear();
    }

    public void OnEnemyDeath(int points)
    {
        playerStats.scoreStats.score += points;
    }
}
