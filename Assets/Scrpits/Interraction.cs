    using System;
using System.Collections;
using System.Collections.Generic;
    using Unity.VisualScripting;
    using UnityEngine;

    public class Interraction : MonoBehaviour,IPlayerInteraction
{
    
    public InteractionType _interactionType;
    private bool isPlaying = false;
    private bool isLightOn = false;
    private Animator animator;
    private readonly int IsChestOpen = Animator.StringToHash("IsChestOpen");
    AudioSource audioData;
    [SerializeField] ScriptableObjectBool IsCampireOn;

    public void OnPlayerInteraction()
    {
        switch (_interactionType)
        {
                

            case InteractionType.Fireplace:
                if (isPlaying == false)
                {
                    gameObject.GetComponent<ParticleSystem>().Play();
                    isPlaying = true;
                    audioData = GetComponent<AudioSource>();
                    audioData.Play(0);
                    IsCampireOn.Bool = true;
                }
                else if(isPlaying == true)
                {
                    gameObject.GetComponent<ParticleSystem>().Stop();
                    isPlaying = false;
                    audioData.Stop();
                    IsCampireOn.Bool = false;
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
        }
    }
}
