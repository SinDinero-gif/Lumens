using System.Collections;
using UnityEngine;


public class LightController : MonoBehaviour
{
    public GameObject title;
    public GameObject buttons;
    private bool _switch = false;
    
    // Start is called before the first frame update
    void Start()
    {
        title.SetActive(false);
        buttons.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(_switch == true)
        {
            StartCoroutine(ButtonShow());
        }
    }

    private IEnumerator ButtonShow()
    {
        _switch = true;
        yield return new WaitForSeconds(0.8f);
        buttons.SetActive(true);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Switch"))
        {
            Debug.Log("Switch");
            title.SetActive(true);
            _switch = true;
        }
    }

}
