using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public Transform target;

    public SpawnManager Spawner;

    private void Awake()
    {
        this.target = GameObject.FindWithTag("Player").transform;
    }

    public void destroy()
    {
        if (Spawner)
        {
            Spawner.currentEnemySpawns -= 1;
        }
        Destroy(this.gameObject);
    }

}
