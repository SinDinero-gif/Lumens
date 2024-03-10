using UnityEngine;

namespace Managers
{
    public class ActivablePlatform : MonoBehaviour, IActivation

    {
        private GameObject _platform;
        [SerializeField] private Animator _platformAnim;
        [SerializeField] private InteractableLever _interactableLever;
        
        private void Update()
        {
            if (_interactableLever._activated)
            {
                Activate();   
            }
        }

        public void Activate()
        {
            _platformAnim.SetTrigger("Activate");
        }

    }
}