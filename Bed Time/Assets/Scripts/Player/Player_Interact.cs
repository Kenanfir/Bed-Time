using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interact : MonoBehaviour
{
    public AudioSource[] soundFX;
    public Game_Manager gameManager;

    private GameObject Door;
    private Transform goToLoc;
    private Collider2D playerColl;

    [SerializeField] private ContactFilter2D intractableFil;
    [SerializeField] private List<Collider2D> interactableObj;

    public bool isInteract = false;
    public bool isHiding = false;
    public bool isSwitchOn = false;
    public bool isShadowOn = false;
    public bool isFootstepsOn = false;
    public bool isScratchesOn = false;
    public bool isRadioOn = false;
    public bool isBlackout = false;

    void Start()
    {
        playerColl = GetComponent<Collider2D>();
        gameManager = gameObject.GetComponent<Game_Manager>();
    }

    void Update()
    {
        playerColl.OverlapCollider(intractableFil, interactableObj);

        foreach(var obj in interactableObj)
        {
            OnCollided(obj.gameObject);
        }
    }

    void OnCollided(GameObject gameObj)
    {
        if (Input.GetKeyDown(KeyCode.E) && !isInteract)
        {
            isInteract = true;
            switch (gameObj.name)
            {
                case ("Door1"):
                    OnInteractDoor1();
                    break;

                case ("Door2"):
                    OnInteractDoor2();
                    break;

                case ("Door3"):
                    OnInteractDoor3();
                    break;

                case ("Door4"):
                    OnInteractDoor4();
                    break;

                case ("Bed"):
                    OnInteractBed();
                    break;

                case ("Closet"):
                    OnInteractCloset();
                    break;

                case ("Radio"):
                    OnInteractRadio();
                    break;

                case ("Switch"):
                    OnInteractSwitch();
                    break;
            }
        }
    }

    void OnInteractDoor1()
    {
        //gameManager.FadeOut();
        Door = GameObject.Find("Door2");
        goToLoc = Door.transform.GetChild(0).transform;                
        gameObject.transform.position = goToLoc.position;
        Debug.Log("Interacted Door1");
        isInteract = false;
        //gameManager.FadeIn();
    }

    void OnInteractDoor2()
    {
        //gameManager.FadeOut();
        Door = GameObject.Find("Door1");
        goToLoc = Door.transform.GetChild(0).transform;
        gameObject.transform.position = goToLoc.position;
        Debug.Log("Interacted Door2");
        isInteract = false;
        //gameManager.FadeIn();
    }

    void OnInteractDoor3()
    {
        //gameManager.FadeOut();
        Door = GameObject.Find("Door4");
        goToLoc = Door.GetComponent<Transform>();
        gameObject.transform.position = goToLoc.position;
        Debug.Log("Interacted Door3");
        isInteract = false;
        //gameManager.FadeIn();
    }

    void OnInteractDoor4()
    {
        //gameManager.FadeOut();
        Door = GameObject.Find("Door3");
        goToLoc = Door.GetComponent<Transform>();
        gameObject.transform.position = goToLoc.position;
        Debug.Log("Interacted Door4");
        isInteract = false;
        //gameManager.FadeIn();
    }

    void OnInteractBed()
    {
        if (!isHiding)
        {
            Debug.Log("Hide");
            isHiding = true;
        }
        else
        {
            Debug.Log("Get out");
            isHiding = false;
        }
        isInteract = false;
    }

    void OnInteractCloset()
    {
        if (!isHiding)
        {
            Debug.Log("Hide");
            isHiding = true;
        }
        else
        {
            Debug.Log("Get out");
            isHiding = false;
        }
        isInteract = false;
    }

    void OnInteractRadio()
    {
        if (isRadioOn)
        {
            Debug.Log("Turn Off Radio");
            isRadioOn = false;
        }
        isInteract = false;
    }

    void OnInteractSwitch()
    {
        if (!isSwitchOn && isBlackout)
        {
            Debug.Log("Lights Back On");
            isSwitchOn = true;
        }
        isInteract = false;
    }
}