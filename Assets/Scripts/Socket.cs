using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socket : MonoBehaviour
{
    public bool empty = true;

    public Transform currentLogicGate;

    public Sprite emptySprite;

    public Sprite notEmptySprite;

    public LevelInitManager levelInitManager;

    public bool overwriteable = true;

    void Start()
    {
        this.levelInitManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelInitManager>();
        if (currentLogicGate && !(empty))
        {
            currentLogicGate.transform.position = this.transform.position;
            currentLogicGate.transform.rotation = this.transform.rotation;
            SpriteRenderer spriteRenderer = this.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = this.notEmptySprite;
        }
    }

    public void placeLogicGate(Transform logicGate)
    {
        if (this.overwriteable && logicGate)
        {
            if (currentLogicGate)
            {
                Destroy(currentLogicGate.gameObject);
            }
            currentLogicGate = logicGate;
            logicGate.parent = this.transform;
            logicGate.transform.position = this.transform.position;
            logicGate.transform.rotation = this.transform.rotation;
            this.empty = false;
            SpriteRenderer spriteRenderer = this.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = this.notEmptySprite;
            if (this.levelInitManager.checkIfLevelComplete())
            {
                this.levelInitManager.endLevelVictory();
            }
            //Debug.Log(this.levelInitManager.checkIfLevelComplete());
        }
    }
}
