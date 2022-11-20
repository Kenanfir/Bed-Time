using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{
    public Sequence_Controller startSequence;
    public CanvasGroup imageFade;

    private bool isGameStart;

    private void Awake()
    {
        //fungsinya buat apa nan?
        //startSequence = GetComponent<Sequence_Controller>();
        
        //fungsinya buat apa nan?(2)
        startSequence.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        isGameStart = false;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isGameStart)
        {
            isGameStart = true;
            startSequence.enabled = true;
        }
    }

    public void FadeIn()
    {
        while (imageFade.alpha >= 1)
        {
            imageFade.alpha -= Time.deltaTime;
        }
    }

    public void FadeOut()
    {
        while (imageFade.alpha == 0)
        {
            imageFade.alpha += Time.deltaTime;
        }
    }
}
