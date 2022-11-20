using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence_Controller : MonoBehaviour
{
    [SerializeField] private string[] sequenceType = new string[] { "Blackout", "Footsteps", "Shadow", "Scratches", "Radio" };
    [SerializeField] private AudioSource[] soundFX;
    [SerializeField] private GameObject imageBlackout;

    public GameObject player;

    private string randSequence;
    private float timeRemain, timeSequence;
    private bool isSequenceStart;
    private Player_Interact interact;
    

    private void Awake()
    {
        interact = player.GetComponent<Player_Interact>();
    }
    // Start is called before the first frame update
    void Start()
    {
        timeRemain = 355;
        timeSequence = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemain > 0)
        {
            timeRemain -= Time.deltaTime;
            if (!isSequenceStart)
            {
                SequenceStart();
            }
            else if (isSequenceStart)
            {
                timeSequence += Time.deltaTime;
                if (timeSequence >= 70)
                {
                    soundFX[0].Play();
                }
                else if (timeSequence >= 90)
                {
                    //mati
                }
                if (timeSequence < 90)
                {
                    switch (randSequence)
                    {
                        case ("Blackout"):
                            BlackoutSequence();
                            break;
                        case ("Footsteps"):
                            FootstepsSequence();
                            break;
                        case ("Shadow"):
                            ShadowSequence();
                            break;
                        case ("Scratches"):
                            ScratchesSequence();
                            break;
                        case ("Radio"):
                            RadioSequence();
                            break;
                    }
                }
            }
        }
        else if (timeRemain <= 0)
        {
            
        }
    }

    void SequenceStart()
    {
        isSequenceStart = true;
        randSequence = sequenceType[Random.Range(0, sequenceType.Length)];
        switch (randSequence)
        {
            case ("Blackout"):
                BlackoutSequence();
                break;
            case ("Footsteps"):
                FootstepsSequence();
                break;
            case ("Shadow"):
                ShadowSequence();
                break;
            case ("Scratches"):
                ScratchesSequence();
                break;
            case ("Radio"):
                RadioSequence();
                break;
        }
    }

    void StopSequence()
    {
        isSequenceStart = false;
        interact.isSwitchOn = false;
        interact.isBlackout = false;
        interact.isRadioOn = false;
        interact.isScratchesOn = false;
        interact.isFootstepsOn = false;
        interact.isShadowOn = false;
        timeSequence = 0;
        soundFX[0].Stop();
        imageBlackout.SetActive(false);
    }

    void NewSequence()
    {

    }

    void BlackoutSequence()
    {
        if (interact.isBlackout == false)
        {
            imageBlackout.SetActive(true);
            interact.isBlackout = true;
            //play sfx
        }
        else if (timeSequence < 90 && interact.isSwitchOn == true)
        {
            StopSequence();
        }
    }

    void FootstepsSequence()
    {
        if (interact.isFootstepsOn == false)
        {
            interact.isRadioOn = true;
            //play sfx
        }
        else if (timeSequence < 90 && interact.isHiding == true)
        {
            StopSequence();
        }
    }

    void ShadowSequence()
    {
        if (interact.isShadowOn == false)
        {
            interact.isRadioOn = true;
            //play sfx
        }
        else if (timeSequence < 90 && interact.isHiding == true)
        {
            StopSequence();
        }
    }

    void ScratchesSequence()
    {
        if (interact.isScratchesOn == false)
        {
            interact.isRadioOn = true;
            //play sfx
        }
        else if (timeSequence < 90 && interact.isHiding == true)
        {
            StopSequence();
        }
    }

    void RadioSequence()
    {
        if (interact.isRadioOn == false)
        {
            interact.isRadioOn = true;
            //play sfx
        }
        else if (timeSequence < 90 && interact.isRadioOn == false)
        {
            StopSequence();
        }
    }
}
