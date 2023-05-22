using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public TextMeshProUGUI interactionText;

    [SerializeField] ScriptableObjectBool SOBool;
    // Start is called before the first frame update
    void Start()
    {
          interactionText.enabled = false;
    }
  
      // Update is called once per frame
      void Update()
      {
          if (SOBool.Bool == true)
          {
              interactionText.enabled = true;
          }
          else
          {
              interactionText.enabled = false;
          }
      }
}
