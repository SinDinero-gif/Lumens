using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableLever : Interactable
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public override void Interact()
    {
        _animator.SetTrigger("Active");
    }
}
