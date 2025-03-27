using System;
using Managers.Activables;
using UnityEngine;


namespace Managers.Interactuables
{
    public class InteractableLever : Interactable
    {
        [SerializeField] private Animator animator;
        [SerializeField] private SpriteRenderer leverHandle;
        private AudioSource _leverSoundEffect;
        
        private static readonly int Active = Animator.StringToHash("Active");

        private void Awake()
        {
            _leverSoundEffect = GetComponent<AudioSource>();
        }

        private void Start()
        {
            LeverColorSwap();
            
        }

        [ContextMenu("Lever Color Swap")]
        private void LeverColorSwap()
        {

            switch (colorInteraction)
            {
                
                
                case Colors.white:
                    leverHandle.color = Color.white;
                    break;
                case Colors.red:
                    leverHandle.color = Color.red;
                    break;
                case Colors.blue:
                    leverHandle.color = Color.blue;
                    break;
                case Colors.green:
                    leverHandle.color = Color.green;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
        }

        public override void Interact()
        {
            if(!_activated)
            {
                _leverSoundEffect.Play();
                animator.SetTrigger(Active);
                _activable.TryGetComponent(out IActivation component);
                component?.Activate();
                _activated = true;    
            }
            
            
        }
    }
}

