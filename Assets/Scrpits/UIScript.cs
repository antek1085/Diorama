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
        SOBool.Bool = false;
    }
  
      // Update is called once per frame
    void Update()
    { 
        interactionText.enabled = SOBool.Bool;
    }
    //zostawiam to ponieważ potrzebowałem w projekcie Scriptable Object chociaż że lepiej było by to zrobić w skrypcie Movement
}
