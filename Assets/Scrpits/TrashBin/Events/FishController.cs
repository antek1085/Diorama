using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FishController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.onFishTriggerEnter += OnFishStart;
    }

    void OnFishStart()
    {
        GetComponent<DOTweenVisualManager>().enabled = true;
    }
}
