﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playback : MonoBehaviour {

    private static Playback instance = null;

    public static Playback Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else 
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
