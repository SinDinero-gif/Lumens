using UnityEngine;

namespace Managers.Activables
{
    [RequireComponent(typeof(Animator))]
    public class ActivablePuerta : MonoBehaviour, IActivation

    {
        private GameObject door;
        [SerializeField]private Animator doorAnim;
        [SerializeField] private AudioClip doorSFx;

        public void Activate()
        {
            doorAnim.SetTrigger("Activate");
            PlayAudioClip();
        }
        private void PlayAudioClip()
        {
            SfxManager.Instance.PlaySoundClip(doorSFx, transform, 0.4f);
        }
    }
}