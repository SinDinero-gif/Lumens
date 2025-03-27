using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Toaster : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ToasterFunction(SceneManager.GetActiveScene().buildIndex + 1));
    }

    private IEnumerator ToasterFunction(int buildIndex)
    {
        float seconds = 1.6f;

        yield return new WaitForSeconds(seconds);

        SceneManager.LoadScene(buildIndex);
    }
}
