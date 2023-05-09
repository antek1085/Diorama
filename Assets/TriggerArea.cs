using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{

   void OnTriggerEnter()
   {
      GameEvents.current.FishTrigggerEnter();
      gameObject.GetComponent<Collider>().enabled = false;
   }
        
}
