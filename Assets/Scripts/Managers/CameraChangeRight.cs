using System;
using System.Collections;
using UnityEngine;

namespace Managers
{
    public class CameraChangeRight : MonoBehaviour
    {
        [SerializeField] private GameObject _camera;
        [SerializeField] private float _cameraOffset = 0f;
        [SerializeField] private GameObject _cameraChangeLeft;
        private bool isCameraChange = false;
        private void Awake()
        {
            _cameraChangeLeft.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {

                isCameraChange = true;

            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                var position = _camera.transform.position;

                if (isCameraChange)
                {
                    _camera.transform.Translate(new Vector2(position.x = _cameraOffset, 
                        position.y));
                    
                    if (_camera.transform.position.x >= _cameraOffset)
                    {
                        var vector3 = _camera.transform.position;
                        vector3.x = _cameraOffset;
                        _camera.transform.position = vector3;
                    }
                    
                }

                LoadCollider();
            }
        }

        private void LoadCollider()
        {
            StartCoroutine(ColliderActivation());
        }

        
        private IEnumerator ColliderActivation()
        {
            float seconds = 1.5f;
            
            yield return new WaitForSeconds(seconds);
            
            _cameraChangeLeft.SetActive(true);
        }
        
        
    }
}