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


    public void Awake()
    {
        interactObject = GetComponent<Interactable>();
    }

    private void Update()
    {
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Portal>(out Portal component))
        {
            currentColor = component.colorPortal;
            ColorLightSwap();
            
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
