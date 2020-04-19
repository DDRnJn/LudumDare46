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
        Vector2 backgroundSize = this.getBackgroundSize();//this.background.GetComponent<SpriteRenderer>().sprite.rect.size;
        float xMax = backgroundSize.x / 2;
        float yMax = backgroundSize.y / 2;

        float spawnX = Random.Range(-xMax, xMax);
        float spawnY = Random.Range(-yMax, yMax);

        if (Mathf.Abs(spawnX) < minDistFromPlayer)
        {
            spawnX = minDistFromPlayer;
        }
        if (Mathf.Abs(spawnY) < minDistFromPlayer)
        {
            spawnY = minDistFromPlayer;
        }

        Vector2 randomPoint = new Vector2(spawnX, spawnY);
        return randomPoint;
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
