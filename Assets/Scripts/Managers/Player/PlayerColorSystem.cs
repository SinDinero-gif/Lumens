using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerColorSystem : MonoBehaviour
{
    private Colors currentColor;
    private ObjectInteract currentObject;
    [SerializeField] private Light2D _lightPlayer;
    private Interactable interactObject;
    [SerializeField] private PlayerMovement playerMovement;

    public bool Interaction => Input.GetKeyDown(KeyCode.E);

    public void Awake()
    {
        interactObject = GetComponent<Interactable>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Interaction)
        {
            interactObject?.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Interactable>(out Interactable component))
        {
            if (component.colorInteraction == currentColor)
            {
                interactObject = component;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Portal>(out Portal portal))
        {
            currentColor = portal.colorPortal;
            ColorLightSwap();
        }
        if(collision.TryGetComponent<Interactable>(out Interactable interactable))
        {
             interactObject = null;
        }
    }

    

    private void ColorLightSwap()
    {
        switch(currentColor)
        {
            case Colors.red:
                _lightPlayer.color = Color.red;
                break;
            case Colors.green:
                _lightPlayer.color = Color.green;
                break;
            case Colors.blue:
                _lightPlayer.color = Color.blue;
                break;
            case Colors.white:
                _lightPlayer.color = Color.white;
                break;
        }
    }


}
