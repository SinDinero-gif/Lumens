using System.Collections;
using Systems.Managers.Audio;
using UnityEngine;


public class LightController : MonoBehaviour
{
    public GameObject title;
    public GameObject buttons;
    
    // Start is called before the first frame update
    void Start()
    {
        title.SetActive(false);
        buttons.SetActive(false);
    }

    private IEnumerator ButtonShow()
    {
        AudioManager.Instance.PlayMusic("Lumens Menu");
        yield return new WaitForSeconds(0.8f);
        buttons.SetActive(true);
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Switch"))
        {
            Debug.Log("Switch");
            title.SetActive(true);
            StartCoroutine(ButtonShow());
           
        }
    }

}
