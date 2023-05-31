using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<DOTweenVisualManager>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
