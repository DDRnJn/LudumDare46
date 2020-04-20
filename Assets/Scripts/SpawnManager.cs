using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform player;
    public List<Transform> enemyTypes;
    public int maxEnemySpawnNum;

    public int currentEnemySpawns = 0;
    public int minSpawnRate;
    public int maxSpawnRate;

    public Transform background;

    public float minDistFromPlayer;
    public float minDistFromDrops;
    public float maxDistFromDrops;


    void Start()
    {
        InvokeRepeating("CreateEnemy", Random.Range(minSpawnRate, maxSpawnRate),
                                       Random.Range(minSpawnRate, maxSpawnRate));
    }

    private Vector2 getEnemySpawnPoint()
    {
        Collider2D collider = this.background.GetComponent<Collider2D>();
        return new Vector2(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y)
        );
    }

    private Vector3 getBackgroundSize()
    {
        Vector2 backgroundSize = this.background.GetComponent<SpriteRenderer>().sprite.rect.size;
        Vector2 scaledbackgroundSize = backgroundSize / this.background.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;

        return scaledbackgroundSize;
    }

    void CreateEnemy()
    {
        if (currentEnemySpawns < maxEnemySpawnNum)
        {
            Transform enemy = this.enemyTypes[Random.Range(0, this.enemyTypes.Count)];
            Transform enemySpawn = Instantiate(enemy, this.getEnemySpawnPoint(), this.transform.rotation);
            EnemyController enemyController = enemySpawn.GetComponent<EnemyController>();
            enemyController.Spawner = this;
            this.currentEnemySpawns += 1;
        }
    }


}
