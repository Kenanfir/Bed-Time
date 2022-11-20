using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact_Door : MonoBehaviour
{
    public GameObject player;
    public Transform goToLoc;
    
    void Start()
    {

    }

    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D playerCol)
    {
        if(playerCol.gameObject.CompareTag("Player"))
        {
            player.transform.position = goToLoc.position;
        }
    }
}
