using System.Collections;
using System.Collections.Generic;
using Managers.Activables;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class SelectButtons : MonoBehaviour
    {
        [SerializeField] private GameObject settingsWindow;
        [SerializeField] private Animator settingsAnimator;

        private void Awake()
        {
            settingsWindow.SetActive(false);
        }
        
        public void PlayButton(int i = 1)
        {
            SceneManager.LoadScene(i);
        }

        public void SettingsButton()
        {
            settingsWindow.SetActive(true);
        }

        public void QuitButton()
        {
            Debug.Log("Saliste de la aplicacion");
            Application.Quit();
        }

        public void GoBackButton()
        {
            StartCoroutine(GoBackFunction());
        }

        private IEnumerator GoBackFunction()
        {
            float seconds = 1.5f;
            settingsAnimator.SetTrigger("Active");
            
            yield return new WaitForSeconds(seconds);
            
            settingsWindow.SetActive(false);
        }
        
    }
    
}