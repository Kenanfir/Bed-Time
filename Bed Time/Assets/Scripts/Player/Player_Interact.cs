using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interact : MonoBehaviour
{
    private GameObject Door;
    private Transform goToLoc;
    private Collider2D playerColl;
    [SerializeField] private ContactFilter2D intractableFil;
    [SerializeField] private List<Collider2D> interactableObj;
    private bool isInteract = false;
    private bool isHiding = false;

    void Start()
    {
        playerColl = GetComponent<Collider2D>();
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
        Door = GameObject.Find("Door2");
        goToLoc = Door.GetComponent<Transform>();
        gameObject.transform.position = goToLoc.position;
        Debug.Log("Interacted Door1");
        isInteract = false;
    }

    void OnInteractDoor2()
    {
        Door = GameObject.Find("Door3");
        goToLoc = Door.GetComponent<Transform>();
        gameObject.transform.position = goToLoc.position;
        Debug.Log("Interacted Door2");
        isInteract = false;
    }

    void OnInteractDoor3()
    {
        Door = GameObject.Find("Door4");
        goToLoc = Door.GetComponent<Transform>();
        gameObject.transform.position = goToLoc.position;
        Debug.Log("Interacted Door3");
        isInteract = false;
    }

    void OnInteractDoor4()
    {
        Door = GameObject.Find("Door1");
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

    void OnInteractSwitch()
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
}