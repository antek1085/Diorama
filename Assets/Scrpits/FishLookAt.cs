using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishLookAt : MonoBehaviour
{
    public Transform FishLook;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(FishLook);
    }
}
