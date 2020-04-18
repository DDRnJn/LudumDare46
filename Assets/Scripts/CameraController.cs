﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(this.player.transform.position.x,
                                              this.player.transform.position.y,
                                              -10);
    }
}
