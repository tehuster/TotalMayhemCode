using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class EnemyManager : MonoBehaviour
{
    public int EnemyAmount;

    public CinemachineTargetGroup targetGroup;


    public List<Transform> spawningPositions;
    public List<GameObject> enemiesGO;
    public GameObject basicEnemy;
    public PlayerScriptable playerStats;
    public LevelScriptable levelStats;
    public SpawnerScriptable[] spawners;

    private GameObject furthestEnemy;

    private void Start()
    {
        levelStats.enemiesGo = enemiesGO;
        levelStats.totalEnemies = enemiesGO.Count;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(SpawnEnemies(0.05f));
        }
    }

    IEnumerator SpawnEnemies(float waitTime)
    {
        int rPos = Random.Range(0, spawningPositions.Count);
        Transform randomSpawnpoint = spawningPositions[rPos];
        int rSpawn = Random.Range(0, spawners.Length);
        Vector3[] enemyPositions = spawners[rSpawn].GetSpawnPositions(randomSpawnpoint.position, EnemyAmount);

        targetGroup.AddMember(randomSpawnpoint, 1, 2);

        foreach (Vector3 enemyPosition in enemyPositions)
        {
            //Replacing with ObjectPooling
            GameObject newEnemy = Instantiate(basicEnemy, enemyPosition, Quaternion.identity);
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
}
