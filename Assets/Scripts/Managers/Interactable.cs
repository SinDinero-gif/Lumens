
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[Serializable]
public enum ObjectInteract
{
    Button,
    Lever,
}


public abstract class Interactable : MonoBehaviour
{
    public Colors colorInteraction;
    public abstract void Interact();
}