using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ReloadScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReloadScenes()
    {
        SceneManager.LoadScene("BedTime");
    }

    IEnumerator ReloadScene()
    {        
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("BedTime");
    }

}
