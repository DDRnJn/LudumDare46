using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private static AudioController instance;

    private static AudioController Instance
    {
        get
        {
            return instance;
        }
    }
    void Awake()
    {
        DontDestroyOnLoad(this);
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
}
