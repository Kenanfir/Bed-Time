using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interact : MonoBehaviour
{
    public AudioSource[] soundFX;
    public Game_Manager gameManager;
    public Player_Movement startMovement;

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
    public bool isRadioSwitch = false;
    public bool isBlackout = false;

    void Start()
    {
        playerColl = GetComponent<Collider2D>();
            
    }
    void Update()
    {
        playerColl.OverlapCollider(intractableFil, interactableObj);

        foreach (var obj in interactableObj)
        {
            OnCollided(obj.gameObject);
        }
    }

    void OnCollided(GameObject gameObj)
    {
        if (Input.GetKeyDown(KeyCode.E) && !isInteract)
        {
            switch (gameObj.name)
            {
                case ("Door1"):
                    isInteract = true;
                    OnInteractDoor1();
                    break;

                case ("Door2"):
                    isInteract = true;
                    OnInteractDoor2();
                    break;

                case ("Door3"):
                    isInteract = true;
                    OnInteractDoor3();
                    break;

                case ("Door4"):
                    isInteract = true;
                    OnInteractDoor4();
                    break;

                case ("Bed"):
                    isInteract = true;
                    OnInteractBed();
                    break;

                case ("Closet"):
                    isInteract = true;
                    OnInteractCloset();
                    break;

                case ("Radio"):
                    isInteract = true;
                    OnInteractRadio();
                    break;

                case ("Switch"):
                    isInteract = true;
                    OnInteractSwitch();
                    break;
            }
        }
    }

    void OnInteractDoor1()
    {           
        Door = GameObject.Find("Door2");
        gameManager.SwitchDoor();
        goToLoc = Door.transform.GetChild(0).transform;
        gameObject.transform.position = goToLoc.position;
        Debug.Log("Interacted Door1");
        isInteract = false;          
    }

    void OnInteractDoor2()
    {            
        Door = GameObject.Find("Door1");
        gameManager.SwitchDoor();
        goToLoc = Door.transform.GetChild(0).transform;
        gameObject.transform.position = goToLoc.position;
        Debug.Log("Interacted Door2");
        isInteract = false;            
    }

    void OnInteractDoor3()
    {       
        Door = GameObject.Find("Door4");
        gameManager.SwitchDoor();
        goToLoc = Door.GetComponent<Transform>();
        gameObject.transform.position = goToLoc.position;
        Debug.Log("Interacted Door3");
        isInteract = false;     
    }

    void OnInteractDoor4()
    {        
        Door = GameObject.Find("Door3");
        gameManager.SwitchDoor();
        goToLoc = Door.GetComponent<Transform>();
        gameObject.transform.position = goToLoc.position;
        Debug.Log("Interacted Door4");
        isInteract = false;        
    }

    void OnInteractBed()
    {
        if (!isHiding)
        {
            Debug.Log("Hide");
            startMovement.enabled = false;
            isHiding = true;
        }
        else
        {
            Debug.Log("Get out");
            startMovement.enabled = true;
            isHiding = false;
        }
        isInteract = false;
    }

    void OnInteractCloset()
    {
        if (!isHiding)
        {
            Debug.Log("Hide");
            startMovement.enabled = false;
            isHiding = true;
        }
        else
        {
            Debug.Log("Get out");
            startMovement.enabled = true;
            isHiding = false;
        }
        isInteract = false;
    }

    void OnInteractRadio()
    {
        if (!isRadioSwitch && isRadioOn)
        {
            Debug.Log("Turn Off Radio");
            isRadioSwitch = true;
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
