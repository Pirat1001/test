using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private RandomWalkerTank enemy;
    private float enemiesToSpawn = 0;
    public GameObject tankPrefab;

    public void SpawnEnemies()
    {
        enemiesToSpawn = Random.Range(0, 3) + enemy.waveCount;

        for(int i = 0; i <= enemiesToSpawn; i++)
        {
            Instantiate(tankPrefab);
        }
    }
}
