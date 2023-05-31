using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float mousevaleY;

    float mouseValueClamp;
    Quaternion rotatione;

    // Start is called before the first frame update
    void Start()
    {
        rotatione = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
       // mousevaleY = Input.mousePosition.x;
       // mouseValueClamp = Mathf.Clamp(mousevaleY, -45f, 45f);
       // transform.eulerAngles = new Vector3(this.transform.eulerAngles.x,mouseValueClamp, this.transform.eulerAngles.z);
       if (Input.GetKeyDown(KeyCode.Q) && rotatione.y < 45f)
       {
           rotatione.y = rotatione.y + 45f;
           transform.rotation = Quaternion.Euler(0, rotatione.y, 0);
       }
       if (Input.GetKeyDown(KeyCode.E) && rotatione.y > -45f)
       {
           rotatione.y = rotatione.y - 45f;
           transform.rotation = Quaternion.Euler(0, rotatione.y, 0);
       }
       

    } 
    
}
