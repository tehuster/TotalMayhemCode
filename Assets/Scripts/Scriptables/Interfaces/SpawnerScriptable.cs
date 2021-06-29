using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnerScriptable : ScriptableObject
{
    public abstract Vector3[] GetSpawnPositions(Vector3 spawnRootPosition, int amount);
}
