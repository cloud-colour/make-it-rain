﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfiguration {

    private static GameConfiguration inst;

    public static GameConfiguration GetInstance()
    {
        if (inst == null)
            inst = new GameConfiguration();

        return inst;
    }

    public float mouseSensitivity; 

    public GameConfiguration()
    {
        mouseSensitivity = 1;
    }
}
