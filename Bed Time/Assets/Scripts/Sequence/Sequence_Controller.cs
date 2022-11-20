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
            randSequence = sequenceType[Random.Range(0, sequenceType.Length)];
            timeRemain -= Time.deltaTime;
            if (!isSequenceStart)
            {
                SequenceStart(randSequence);
            }
            else if (isSequenceStart)
            {
                timeSequence += Time.deltaTime;
                if (timeSequence >= 40)
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
                        /*case ("Radio"):
                            RadioSequence();
                            break;*/
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
        switch (random)
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
            /*case ("Radio"):
                RadioSequence();
                break;*/
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

    void BlackoutSequence()
    {
        if (interact.isBlackout == false)
        {
            imageBlackout.SetActive(true);
            interact.isBlackout = true;
            //play sfx
        }
        else if (timeSequence < 60 && interact.isSwitchOn == true)
        {
            interact.isBlackout = false;
            interact.isSwitchOn = false;
            imageBlackout.SetActive(false);
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
        else if (timeSequence < 60 && interact.isHiding == true)
        {
            interact.isFootstepsOn = false;
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
        else if (timeSequence < 60 && interact.isHiding == true)
        {
            interact.isShadowOn = false;
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
        else if (timeSequence < 60 && interact.isHiding == true)
        {
            interact.isScratchesOn = false;
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
        else if (timeSequence < 60 && interact.isRadioSwitch == true)
        {
            interact.isRadioOn = false;
            StopSequence();
        }
    }
}
