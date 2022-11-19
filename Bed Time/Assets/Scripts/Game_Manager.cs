using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{
    private CanvasGroup imageFade;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeIn()
    {
        while (imageFade.alpha >= 1)
        {
            imageFade.alpha += Time.deltaTime;
        }
    }

    public void FadeOut()
    {
        while (imageFade.alpha == 0)
        {
            imageFade.alpha -= Time.deltaTime;
        }
    }
}
