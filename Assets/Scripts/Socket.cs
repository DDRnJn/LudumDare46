using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socket : MonoBehaviour
{
    public bool empty = true;

    public Transform currentLogicGate;

    public Sprite emptySprite;

    public Sprite notEmptySprite;

    public void placeLogicGate(Transform logicGate)
    {
        if (logicGate)
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
        }
    }
}
