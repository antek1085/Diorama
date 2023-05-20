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
    Rigidbody rb;
    Vector3 moveDirection;
    private NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
        animator.GetComponent<Animation>();
        interactionText.enabled = false;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isInteractable == true && Input.GetKeyDown(KeyCode.Space))
        {
            _playerInteraction?.OnPlayerInteraction();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            SetDestinationToMousePosition();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        _playerInteraction = other.GetComponent<IPlayerInteraction>();
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
            case  InteractionType.Shark:
                break;
            case InteractionType.coconutfall:
                _playerInteraction?.OnPlayerInteraction();
                break;
        }
        
    }
    void SetDestinationToMousePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.red,1000f);
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(1);
            agent.SetDestination(hit.point);
        }
    } 
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
}
