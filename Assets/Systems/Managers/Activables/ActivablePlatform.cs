using Managers.Interactuables;
using UnityEngine;

namespace Managers.Activables
{
    public class ActivablePlatform : MonoBehaviour, IActivation

    {
        private GameObject _platform;
        [SerializeField] private Animator _platformAnim;
        [SerializeField] private InteractableLever _interactableLever;

        public void Activate()
        {
            _platformAnim.SetTrigger("Activate");
        }

    }
}