﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSpawnManager : MonoBehaviour
{
    public Transform AndGate;
    public Transform OrGate;
    public Transform NotGate;
    public Transform background;

    public int maxAndGates;
    public int maxOrGates;
    public int maxNotGates;

    public int currentAndGates;
    public int currentOrGates;
    public int currentNotGates;

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

    void SpawnGate()
    {
        if (currentAndGates < maxAndGates)
        {
            Transform andGateSpawn = Instantiate(this.AndGate, this.getEnemySpawnPoint(), this.transform.rotation);
            this.currentAndGates++;
            LogicGateSpawn gateSpawn = andGateSpawn.GetComponent<LogicGateSpawn>();
            gateSpawn.Spawner = this;
        }
        if (currentOrGates < maxOrGates)
        {
            Transform ordGateSpawn = Instantiate(this.OrGate, this.getEnemySpawnPoint(), this.transform.rotation);
            this.currentOrGates++;
            LogicGateSpawn gateSpawn = ordGateSpawn.GetComponent<LogicGateSpawn>();
            gateSpawn.Spawner = this;
        }
        if (currentNotGates < maxNotGates)
        {
            Transform notGateSpawn = Instantiate(this.NotGate, this.getEnemySpawnPoint(), this.transform.rotation);
            this.currentNotGates++;
            LogicGateSpawn gateSpawn = notGateSpawn.GetComponent<LogicGateSpawn>();
            gateSpawn.Spawner = this;
        }
    }

    void Update()
    {
        this.SpawnGate();
    }
}
