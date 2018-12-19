using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Configuration")]

public class WaveConfig : ScriptableObject {

    //Config parameters
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float spawnInterval = 0.2f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] int enemyCount = 10;
    [SerializeField] float moveSpeed = 4f;

    public GameObject GetEnemyPrefab()          { return enemyPrefab; }

    public List<Transform> GetWaypoints()
    {
        var waveWaypoints = new List<Transform>();

        foreach (Transform child in pathPrefab.transform)
        {
            waveWaypoints.Add(child);
        }

        return waveWaypoints;
    }

    public float      GetSpawnInterval()        { return spawnInterval; }

    public float      GetSpawnRandomFactor()    { return spawnRandomFactor; }

    public int        GetEnemyCount()           { return enemyCount; }

    public float      GetMoveSpeed()            { return moveSpeed; }

}
