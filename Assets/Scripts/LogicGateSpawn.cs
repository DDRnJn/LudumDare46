using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicGateSpawn : MonoBehaviour
{
    public GateSpawnManager Spawner;

    public string spawnType;

    public void destroy()
    {
        if (Spawner)
        {
            if (spawnType == "AND")
            {
                this.Spawner.currentAndGates--;
            }
            if (spawnType == "OR")
            {
                this.Spawner.currentOrGates--;
            }
            if (spawnType == "NOT")
            {
                this.Spawner.currentNotGates--;
            }
        }
        Destroy(this.gameObject);
    }

}
