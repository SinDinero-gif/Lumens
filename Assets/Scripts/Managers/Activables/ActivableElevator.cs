using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers.Activables
{
    public class ActivableElevator : MonoBehaviour, IActivation
    {
        private Animator transitionCanvas;
        private float transitionTime = 3.5f;
        [SerializeField] private bool canAdvance;
        
        private void Start()
        {
            transitionCanvas = GetComponent<Animator>();
        }
    
        
        public void Activate()
        {
            Debug.Log("Activate");
            if (canAdvance)
            {
                StartCoroutine(TransitionLevel(SceneManager.GetActiveScene().buildIndex + 1));
            }
            else
            {
                StartCoroutine(TransitionMenu());
            }
        }

        private IEnumerator TransitionLevel(int levelIndex)
        {
            transitionCanvas?.SetTrigger("Transition");

            yield return new WaitForSeconds(transitionTime);

            SceneManager.LoadScene(levelIndex);
        }
        
        private IEnumerator TransitionMenu()
        {
            transitionCanvas?.SetTrigger("Transition");

            yield return new WaitForSeconds(transitionTime);

            SceneManager.LoadScene(0);
        }

        
    }
}