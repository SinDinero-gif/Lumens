using System;
using UnityEngine;

namespace Managers
{
    public class InteractableButton : Interactable
    {
        private Animator _animator;
        private SpriteRenderer _buttonSprite;
        public bool _activated = false;
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();

        }

        private void Start()
        {
            ButtonColorSwap();
        }

        [ContextMenu("Button Color Swap")]
        private void ButtonColorSwap()
        {
            _buttonSprite = GetComponent<SpriteRenderer>();
            
            switch (colorInteraction)
            {
                case Colors.white:
                    _buttonSprite.color = Color.white;
                    break;
                case Colors.red:
                    _buttonSprite.color = Color.red;
                    break;
                case Colors.blue:
                    _buttonSprite.color = Color.blue;
                    break;
                case Colors.green:
                    _buttonSprite.color = Color.green;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override void Interact()
        {
            _animator.SetTrigger("Active");
            _activated = true;
        }
    }    
}

