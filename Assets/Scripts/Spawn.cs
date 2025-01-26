using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform enemyPrefeb;
    public int numberOfEnemies;
    public List<Enemy> enemies;
    public float bounds;
    public float spawnRadius;
    void Start()
    {
        enemies = new List<Enemy>();
        SpawnMonster(enemyPrefeb, numberOfEnemies);
        enemies.AddRange(FindObjectsOfType<Enemy>());
    }

    void SpawnMonster(Transform prefeb, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(prefeb, new Vector3(Random.Range(-spawnRadius, spawnRadius),0 , Random.Range(-spawnRadius, spawnRadius)),
                Quaternion.identity);
        }
    }
}
