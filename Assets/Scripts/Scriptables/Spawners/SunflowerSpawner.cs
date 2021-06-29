using UnityEngine;


[CreateAssetMenu(fileName = "SunflowerSpawner", menuName = "Scriptables/Spawners/Sunflower", order = 0)]
public class SunflowerSpawner : SpawnerScriptable
{
    [SerializeField] private float degree;
    [SerializeField] private float scale;

    public override Vector3[] GetSpawnPositions(Vector3 spawnRootPosition, int amount)
    {
        Vector3[] spawnPositions = new Vector3[amount];

        for (int i = 0; i < spawnPositions.Length; i++)
        {
            spawnPositions[i] = CalculateSunFlowerPosition(degree, scale, i);
            spawnPositions[i] += spawnRootPosition;
        }

        return spawnPositions;
    }
    private Vector3 CalculateSunFlowerPosition(float degree, float scale, int amount)
    {
        double angle = amount * (degree * Mathf.Deg2Rad);
        float r = scale * Mathf.Sqrt(amount);
        float x = r * (float)System.Math.Cos(angle);
        float z = r * (float)System.Math.Sin(angle);
        Vector3 position = new Vector3(x, 0, z);
        return position;
    }
}
