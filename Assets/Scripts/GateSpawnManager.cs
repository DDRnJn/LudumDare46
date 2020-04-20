using System.Collections;
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
        Vector2 backgroundSize = this.getBackgroundSize();//this.background.GetComponent<SpriteRenderer>().sprite.rect.size;
        float xMax = (backgroundSize.x * this.background.transform.localScale.x) / 2;
        float yMax = (backgroundSize.y * this.background.transform.localScale.y) / 2;
        float xMin = this.background.transform.position.x - xMax;
        float yMin = this.background.transform.position.y - yMax;

        float spawnX = Random.Range(xMin, xMax);
        float spawnY = Random.Range(yMin, yMax);

        Vector2 randomPoint = new Vector2(spawnX, spawnY);
        return randomPoint;
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
