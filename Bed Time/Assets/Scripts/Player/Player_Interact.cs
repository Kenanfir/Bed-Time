using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interact : MonoBehaviour
{
    private Collider2D interactableColl;
    [SerializeField] private ContactFilter2D intractableFil;
    [SerializeField] private List<Collider2D> interactableObj;

    void Start()
    {
        interactableColl = GetComponent<Collider2D>();
    }

    void Update()
    {
        interactableColl.OverlapCollider(intractableFil, interactableObj);

        foreach(var obj in interactableObj)
        {
            OnCollided(obj.gameObject);
        }
    }

    void OnCollided(GameObject gameObj)
    {
        if (Input.GetKey(KeyCode.E))
        {
            OnInteract(gameObj.gameObject);
        }
    }

    void OnInteract(GameObject gameObj)
    {
        Debug.Log("Interact With" + gameObj.name);
    }
}