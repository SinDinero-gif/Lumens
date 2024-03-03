using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightController : MonoBehaviour
{
    public SpriteRenderer _lightbulb;
    public Light2D lightbulbbloom;

    // Start is called before the first frame update
    void Start()
    {
        
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
            _lightbulb.color =  Color.red;
            lightbulbbloom.color = Color.red;
        }
    }

}
