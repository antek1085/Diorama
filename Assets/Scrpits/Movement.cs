using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Tilemaps;

public class Movement : MonoBehaviour
{
    Vector3 mousePosition;
    
    public Animator animator;
    float tarDistance = 1f;
    InteractionType _interactionType;
    IPlayerInteraction _playerInteraction;
    public TextMeshProUGUI interactionText;
    bool isInteractable;
    public float moveSpeed;
    float horizontalInput;
    float verticalInput;
    Rigidbody rb;
    Vector3 moveDirection;
    public Transform orientation;


    // Start is called before the first frame update
    void Start()
    {
        animator.GetComponent<Animation>();
        interactionText.enabled = false;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInteractable == true && Input.GetKeyDown(KeyCode.Space))
        {
            _playerInteraction?.OnPlayerInteraction();
        }
        MyInput();
        
    }
    void FixedUpdate()
    {
        MovePlayer();
    }

    void MyInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }
    void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection * moveSpeed * 10);
    }

    void OnTriggerEnter(Collider other)
    {
        _playerInteraction = other.GetComponent<IPlayerInteraction>();
        Debug.Log("3");
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
            case InteractionType.SoS:
                InTrigger();
                break;
            default:
                break;
        }
        
    }
 /*void SetDestinationToMousePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            agent.SetDestination(hit.point);
        }
    } */
    void OnTriggerExit(Collider other)
    {
        OutOfTrigger();
    }

    void InTrigger()
    {
        isInteractable = true;
        interactionText.enabled = true;
    }
    void OutOfTrigger()
    {
        isInteractable = false;
        interactionText.enabled = false;
    }
    void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
            
    }
}
