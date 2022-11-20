using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public Sequence_Controller startSequence;
    public Player_Movement startMovement;
    public Player_Interact startInteract;
    public Player_Life playerLife;
    //public CanvasGroup imageFade;
    public Image img;
    
    public Rigidbody2D playerRb;
    private bool isGameStart;
   


    public void SwitchDoor()
    {        
        // fades the image out when you click
        StartCoroutine(FadeImage(true));
        StartCoroutine(PlayerBodyType());
    }

    private void Awake()
    {
        Game_Manager instance = this;
        startSequence.enabled = false;
        startMovement.enabled = false;
        startInteract.enabled = false;
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
            Debug.Log(isGameStart);
            isGameStart = true;
            Debug.Log(isGameStart);
            startSequence.enabled = true;
            startMovement.enabled = true;
            startInteract.enabled = true;
        }

        if (playerLife.isDead)
        {
            StartCoroutine(FadeImage(true));
            SceneManager.LoadScene("Transition");
        }
    }


    IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return new WaitForSeconds(0.013f);
            }
        }
        // fade from transparent to opaque
        else
        {
            playerRb.bodyType = RigidbodyType2D.Dynamic;
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime*0.5f)
            {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                
                yield return null;
            }
            
        }
    }

    IEnumerator PlayerBodyType()
    {
        playerRb.bodyType = RigidbodyType2D.Static;
        yield return new WaitForSeconds(1f);
        playerRb.bodyType = RigidbodyType2D.Dynamic;
    }
}


