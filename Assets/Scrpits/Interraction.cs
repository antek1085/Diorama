    using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interraction : MonoBehaviour,IPlayerInteraction
{
    public InteractionType _interactionType;
    public void OnPlayerInteraction()
    {
        switch (_interactionType)
        {

            case InteractionType.Fireplace:
                 Debug.Log("1");
                break;
            case InteractionType.ChestOpen:
                break;
            case InteractionType.LightOn:
                break;
            case InteractionType.SoS:
                break;
        }
    }
}
