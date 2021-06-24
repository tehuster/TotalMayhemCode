using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class EnemyManager : MonoBehaviour
{
    public float degree;
    public float scale;
    public int EnemyAmount;


    public List<Transform> spawningPositions;
    public List<GameObject> enemiesGO;
    public GameObject basicEnemy;
    public PlayerScriptable playerStats;
    public LevelScriptable levelStats;
    private void Start()
    {
        levelStats.enemiesGo = enemiesGO;
        levelStats.totalEnemies = enemiesGO.Count;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int r = Random.Range(0, spawningPositions.Count);

            for (int i = 0; i < EnemyAmount; i++)
            {
                Vector3 newPosition = CalculatePosition(Random.Range(0f, 1f), Random.Range(0f, 1f), i);
                newPosition += spawningPositions[r].position;

                GameObject newEnemy = Instantiate(basicEnemy, newPosition, Quaternion.identity);
                newEnemy.GetComponent<BaseEnemy>().enemyManager = this;
                enemiesGO.Add(newEnemy);
            }
        }
    }
    private Vector3 CalculatePosition(float degree, float scale, int amount)
    {
        double angle = amount * (degree * Mathf.Deg2Rad);
        float r = scale * Mathf.Sqrt(amount);
        float x = r * (float)System.Math.Cos(angle);
        float z = r * (float)System.Math.Sin(angle);
        Vector3 position = new Vector3(x, 0, z);
        return position;
    }
}
