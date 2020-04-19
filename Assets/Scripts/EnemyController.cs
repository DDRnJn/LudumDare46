﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = .05f;
    public Sprite enemyImage;
    public Transform target;

    private void Awake()
    {
        this.target = GameObject.FindWithTag("Player").transform;
    }

}
