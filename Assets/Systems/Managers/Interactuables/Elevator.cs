using System;
using Managers.Activables;
using UnityEngine;

namespace Managers.Interactuables
{
    public class Elevator : Interactable
    {
        private SpriteRenderer _elevatorSprite;
        [SerializeField] private AudioSource _elevatorSoundEffect;

        private void Start()
        {
            ElevatorColorSwap();
        }

        [ContextMenu("Elevator Color Swap")]
        private void ElevatorColorSwap()
        {
            _elevatorSprite = GetComponent<SpriteRenderer>();
            
            switch (colorInteraction)
            {
                case Colors.white:
                    _elevatorSprite.color = Color.white;
                    break;
                case Colors.red:
                    _elevatorSprite.color = Color.red;
                    break;
                case Colors.blue:
                    _elevatorSprite.color = Color.blue;
                    break;
                case Colors.green:
                    _elevatorSprite.color = Color.green;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override void Interact()
        {
            if (!_activated)
            {
                _elevatorSoundEffect.Play();
                _activable.TryGetComponent(out IActivation component);
                component?.Activate();
            }
        }
    }
}