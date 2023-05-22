using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampfireLightControler : MonoBehaviour
{
    [SerializeField] ScriptableObjectBool IsCampfireOn;

    void Awake()
    {
        IsCampfireOn.Bool = false;
    }
    void Update()
    {
        if (IsCampfireOn.Bool == true)
        {
            GetComponent<Light>().enabled = true;
        }
        else
        {
            GetComponent<Light>().enabled = false;
        }
        
    }
}
