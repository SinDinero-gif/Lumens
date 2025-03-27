using Systems.Player;
using UnityEngine;

namespace Systems.Managers.Player
{
    public class PlayerColorSystem : MonoBehaviour
    {
        [SerializeField] private Colors currentColor;
        private ObjectInteract currentObject;
        private Interactable interactObject;
        [SerializeField] private PlayerMovement playerMovement;

        public bool Interaction => Input.GetKeyDown(KeyCode.E);

        public void Awake()
        {
            interactObject = GetComponent<Interactable>();
            playerMovement = GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            if (Interaction)
            {
                interactObject?.Interact();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent<Interactable>(out Interactable component))
            {
                if (component.colorInteraction == currentColor)
                {
                    interactObject = component;
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if(collision.TryGetComponent<Portal>(out Portal portal))
            {
                currentColor = portal.colorPortal;
                ColorLightSwap();
            }
            if(collision.TryGetComponent<Interactable>(out Interactable interactable))
            {
                interactObject = null;
            }
        }

    
        [ContextMenu("Color Light Swap")]
        private void ColorLightSwap()
        {
            switch(currentColor)
            {
                case Colors.red:
                    playerMovement.playerSprite.color = Color.red;
                    break;
                case Colors.green:
                    playerMovement.playerSprite.color = Color.green;
                    break;
                case Colors.blue:
                    playerMovement.playerSprite.color = Color.blue;
                    break;
                case Colors.white:
                    playerMovement.playerSprite.color = Color.white;
                    break;
            }
        }


    }
}
