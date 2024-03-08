using System;
using UnityEngine;

namespace Managers
{
    public class ActivablePortal : MonoBehaviour, IActivation

    {
        [SerializeField] private GameObject Portal;
        [SerializeField] private InteractableButton _interactableButton;

        public void Awake()
        {
            Portal.SetActive(false);
        }

        private void Update()
        {
            if (_interactableButton._activated)
            {
                Activate();   
            }
        }

        public void Activate()
        {
            Portal.SetActive(true);
        }
        
    }
}