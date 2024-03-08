using System;
using UnityEngine;

namespace Managers
{
    [RequireComponent(typeof(Animator))]
    public class ActivablePuerta : MonoBehaviour, IActivation

    {
        private GameObject door;
        [SerializeField]private Animator doorAnim;
        [SerializeField] private InteractableButton _interactableButton;

        private void Update()
        {
            if (_interactableButton._activated)
            {
                Activate();   
            }
        }

        public void Activate()
        {
           doorAnim.SetTrigger("Activate");
        }
    }
}