using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionPlayerTrigger : MonoBehaviour
{
    InteractionType _interactionType;
    IPlayerInteraction _playerInteraction;
    bool isInteractable;

   [SerializeField] ScriptableObjectBool SOBool;

   // Update is called once per frame
   private void Awake()
   {
       SOBool.Bool = false;
   }

   void Update()
    {
        if (isInteractable == true && Input.GetKeyDown(KeyCode.Space))
        {
            _playerInteraction?.OnPlayerInteraction();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        _playerInteraction = other.GetComponent<IPlayerInteraction>();
        switch (_interactionType)
        {
            case InteractionType.Fireplace:
                InTrigger();
                break;
            case InteractionType.ChestOpen:
                InTrigger();
                break;
            case InteractionType.LightOn:
                InTrigger();
                break;
        }
        
    }
    void OnTriggerExit(Collider other)
    {
        OutOfTrigger();
    }

    void InTrigger()
    {
        isInteractable = true;
        SOBool.Bool = true;
    }
    void OutOfTrigger()
    {
        isInteractable = false; 
        SOBool.Bool = false;
    }
}
