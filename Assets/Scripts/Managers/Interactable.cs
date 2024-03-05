using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Interactable : MonoBehaviour
{
    public Colors colorInteraction;
    public ObjectInteract interaction;
    [SerializeField] private Animator _ObjectAnimator;

    private bool _isButtonActive = false;
    private bool _isLeverActive = false;

    private void Start()
    {
        _ObjectAnimator = GetComponent<Animator>();
    }

    public void ButtonMovement()
    {
        _ObjectAnimator.SetTrigger("ActiveButton");
        _isButtonActive = true;

    }

    public void LeverMovement()
    {
        _ObjectAnimator.SetTrigger("ActiveLever");
        _isLeverActive = true;
    }
}
