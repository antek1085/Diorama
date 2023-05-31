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
    private AudioSource audioData;
    [SerializeField] ScriptableObjectBool IsCampireOn;
    private ParticleSystem particleSystem;
    private Light light;
    private string animatorBool = "New Trigger";
    

    private void Awake()
    {
      particleSystem = this.GetComponent<ParticleSystem>();
      light = GetComponent<Light>();
    }

    public void OnPlayerInteraction()
    {
        switch (_interactionType)
        {
                

            case InteractionType.Fireplace:
                if (isPlaying == false)
                {
                    particleSystem.Play();
                    isPlaying = true;
                    audioData = GetComponent<AudioSource>();
                    audioData.Play(0);
                    IsCampireOn.Bool = true;
                }
                else if(isPlaying == true)
                {
                    particleSystem.Stop();
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
               animator.SetTrigger(animatorBool);
              
               break;
            case InteractionType.LightOn:
                if (isLightOn == false)
                {
                    light.enabled = true;
                    isLightOn = true;
                    
                }
                else if (isLightOn == true)
                {
                    light.enabled = false;
                    isLightOn = false;
                }
                break;
        }
    }
}
