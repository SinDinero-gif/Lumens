using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Serialization;

public class LightController : MonoBehaviour
{
    public GameObject title;
    
    // Start is called before the first frame update
    void Start()
    {
        title.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Switch"))
        {
            Debug.Log("Switch");
            title.SetActive(true);
        }
    }

}
