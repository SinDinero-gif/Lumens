
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

namespace Managers.Interactuables
{
    
}
public abstract class Interactable : MonoBehaviour
{
    public Colors colorInteraction;
    protected bool _activated = false;
    [SerializeField] protected GameObject _activable;
    public abstract void Interact();
}