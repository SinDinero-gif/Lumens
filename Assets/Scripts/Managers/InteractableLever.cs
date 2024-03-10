using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Managers
{
    public class InteractableLever : Interactable
    {
        [SerializeField] private Animator animator;
        [SerializeField] private SpriteRenderer leverHandle;
        [SerializeField] private AudioSource leverSoundEffect;
        public bool _activated = false;
        
        private static readonly int Active = Animator.StringToHash("Active");

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
            leverSoundEffect.Play();
            animator.SetTrigger(Active);
            _activated = true;
            
        }
    }
}

