using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<Transform> enemyTypes;
    public int maxEnemySpawnNum;

    public int currentEnemySpawns;
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
        Vector2 randomPoint = new Vector2(Random.Range(-xMax, xMax), Random.Range(-yMax, yMax));
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
        Transform enemy = this.enemyTypes[Random.Range(0, this.enemyTypes.Count)];
        Instantiate(enemy, this.getEnemySpawnPoint(), this.transform.rotation);
    }


}
