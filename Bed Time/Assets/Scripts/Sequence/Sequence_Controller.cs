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
                isSequenceStart = true;
                SequenceStart(randSequence);
            }
            else if (isSequenceStart)
            {
                timeSequence += Time.deltaTime;
                if (timeSequence >= 40 && timeSequence <= 60)
                {
                    soundFX[0].Play();
                }
                else if (timeSequence >= 60)
                {
                    player.GetComponent<Player_Life>().Die();
                }
                if (timeSequence < 60)
                {
                    switch (randSequence)
                    {
                        case ("Blackout"):
                            BlackoutSequenceCheck();
                            break;
                        case ("Footsteps"):
                            FootstepsSequenceCheck();
                            break;
                        case ("Shadow"):
                            ShadowSequenceCheck();
                            break;
                        case ("Scratches"):
                            ScratchesSequenceCheck();
                            break;
                        case ("Radio"):
                            RadioSequenceCheck();
                            break;
                    }
                }
            }
        }
        else if (timeRemain <= 0)
        {
            
        }
    }

    void SequenceStart(string random)
    {
        randSequence = sequenceType[Random.Range(0, sequenceType.Length)];
        switch (randSequence)
        {
            case ("Blackout"):
                BlackoutSequenceOn();
                break;
            case ("Footsteps"):
                FootstepsSequenceOn();
                break;
            case ("Shadow"):
                ShadowSequenceOn();
                break;
            case ("Scratches"):
                ScratchesSequenceOn();
                break;
            case ("Radio"):
                RadioSequenceOn();
                break;
        }
    }

    void StopSequence()
    {
        isSequenceStart = false;
        timeSequence = 0;
        soundFX[0].Stop();
    }

    void NewSequence()
    {

    }

    void BlackoutSequenceOn()
    {
        if (interact.isBlackout == false)
        {
            imageBlackout.SetActive(true);
            interact.isBlackout = true;
            //play sfx
        }
    }

    void BlackoutSequenceCheck()
    {
        if (timeSequence < 60 && interact.isSwitchOn == true && interact.isBlackout == true)
        {
            interact.isBlackout = false;
            interact.isSwitchOn = false;
            imageBlackout.SetActive(false);
            StopSequence();
        }
    }

    void FootstepsSequenceOn()
    {
        if (interact.isFootstepsOn == false)
        {
            interact.isFootstepsOn = true;
            //play sfx
        }
    }

    void FootstepsSequenceCheck()
    {
        if (timeSequence < 60 && interact.isHiding == true)
        {
            interact.isFootstepsOn = false;
            StopSequence();
        }
    }

    void ShadowSequenceOn()
    {
        if (interact.isShadowOn == false)
        {
            interact.isShadowOn = true;
            //play sfx
        }
    }

    void ShadowSequenceCheck()
    {
        if (timeSequence < 60 && interact.isHiding == true)
        {
            interact.isShadowOn = false;
            StopSequence();
        }
    }

    void ScratchesSequenceOn()
    {
        if (interact.isScratchesOn == false)
        {
            interact.isScratchesOn = true;
            //play sfx
        }
    }

    void ScratchesSequenceCheck()
    {
        if (timeSequence < 60 && interact.isHiding == true)
        {
            interact.isScratchesOn = false;
            StopSequence();
        }
    }

    void RadioSequenceOn()
    {
        if (interact.isRadioOn == false)
        {
            interact.isRadioOn = true;
            //play sfx
        }
    }

    void RadioSequenceCheck()
    {
        if (timeSequence < 60 && interact.isRadioSwitch == true)
        {
            interact.isRadioOn = false;
            StopSequence();
        }
    }
}
