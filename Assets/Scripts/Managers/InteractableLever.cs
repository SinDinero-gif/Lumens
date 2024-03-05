using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableLever : Interactable
{
    private Animator _animator;
    [SerializeField] GameObject button;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        button.SetActive(false);
    }

    public override void Interact()
    {
        _animator.SetTrigger("Active");
        button.SetActive(true);
    }
}
