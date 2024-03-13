using System;
using UnityEngine;

namespace Managers
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] private GameObject gameOverWindow;

        private void Awake()
        {
            gameOverWindow.SetActive(false);
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                gameOverWindow.SetActive(true);
            }
        }
    }
}