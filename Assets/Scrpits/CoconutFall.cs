using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoconutFall : MonoBehaviour
{
    AudioSource audioData;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObject.GetComponent<Rigidbody>().useGravity = enabled;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Island")
        {
            audioData = GetComponent<AudioSource>();
            audioData.Play(0);
            Invoke("DisableAudio", 2);
        }
    }

    void DisableAudio()
    {
        audioData.enabled = false;
    }
}
