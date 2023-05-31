using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;
    // Start is called before the first frame update

    void Awake()
    {
        current = this;
    }

    public event Action onFishTriggerEnter;
    public void FishTrigggerEnter()
    {
        if (onFishTriggerEnter != null)
        {
            onFishTriggerEnter();
        }
    }
}
