using System;
using Managers.Interactuables;
using UnityEngine;

namespace Managers.Activables
{
    public class ActivablePortal : MonoBehaviour, IActivation

    {
        [SerializeField] private GameObject Portal;
        [SerializeField] private InteractableButton _interactableButton;

        public void Awake()
        {
            Portal.SetActive(false);
        }

        public void Activate()
        {
            Portal.SetActive(true);
        }
        
    }
}