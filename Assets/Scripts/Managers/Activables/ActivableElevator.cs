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

        private void Start()
        {
            transitionCanvas = GetComponent<Animator>();
        }
    
        
        public void Activate()
        {
            StartCoroutine(TransitionLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }

        private IEnumerator TransitionLevel(int levelIndex)
        {
            transitionCanvas?.SetTrigger("Transition");

            yield return new WaitForSeconds(transitionTime);

            SceneManager.LoadScene(levelIndex);
        }

        
    }
}