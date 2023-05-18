    using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Interraction : MonoBehaviour,IPlayerInteraction
{
    
    public InteractionType _interactionType;
    private bool isPlaying = false;
    private bool isLightOn = false;
    private Animator animator;
    private readonly int IsChestOpen = Animator.StringToHash("IsChestOpen");

    public void OnPlayerInteraction()
    {
        switch (_interactionType)
        {
                

            case InteractionType.Fireplace:
                if (isPlaying == false)
                {
                    gameObject.GetComponent<ParticleSystem>().Play();
                    isPlaying = true;
                }
                else if(isPlaying == true)
                {
                    Debug.Log(2);
                    gameObject.GetComponent<ParticleSystem>().Stop();
                    isPlaying = false;
                }
                break;
            case InteractionType.ChestOpen:
               animator = GetComponent<Animator>();
               if (animator.GetBool(IsChestOpen))
               {
                   animator.SetBool(IsChestOpen, false);
                   break;
               }
               animator.SetBool(IsChestOpen, true);
               animator.SetTrigger("New Trigger");
               break;
            case InteractionType.LightOn:
                if (isLightOn == false)
                {
                    gameObject.GetComponent<Light>().enabled = true;
                    isLightOn = true;
                }
                else if (isLightOn == true)
                {
                    gameObject.GetComponent<Light>().enabled = false;
                    isLightOn = false;
                }

                break;
            case InteractionType.Shark:
                GameEvents.current.FishTrigggerEnter();
                break;
        }
    }
}
