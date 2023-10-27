using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence_Controller : MonoBehaviour
{
    [SerializeField] private string[] sequenceType = new string[] { "Blackout", "Footsteps", "Shadow", "Scratches", "Radio" };
    [SerializeField] private AudioClip[] soundFX;
    [SerializeField] private GameObject imageBlackout;
    [SerializeField] private GameObject imageShadow;

    public GameObject player;
    public AudioSource sound;

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
            if (!isSequenceStart && timeRemain % 60 == 0)
            {
                isSequenceStart = true;
                SequenceStart(randSequence);
            }
            else if (isSequenceStart)
            {
                timeSequence += Time.deltaTime;
                if (timeSequence >= 40 && timeSequence <= 60)
                {
                    sound.clip = soundFX[0];
                    sound.Play();
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
        sound.Stop();
    }

    void NewSequence()
    {

    }

    void BlackoutSequenceOn()
    {
        if (interact.isBlackout == false)
        {
            sound.clip = soundFX[1];
            sound.Play();
            imageBlackout.SetActive(true);
            interact.isBlackout = true;
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
            sound.clip = soundFX[2];
            sound.Play();
            interact.isFootstepsOn = true;
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
            sound.clip = soundFX[3];
            sound.Play();
            imageShadow.SetActive(true);
            interact.isShadowOn = true;
        }
    }

    void ShadowSequenceCheck()
    {
        if (timeSequence < 60 && interact.isHiding == true)
        {
            interact.isShadowOn = false;
            imageShadow.SetActive(false);
            StopSequence();
        }
    }

    void ScratchesSequenceOn()
    {
        if (interact.isScratchesOn == false)
        {
            sound.clip = soundFX[4];
            sound.Play();
            interact.isScratchesOn = true;
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
            sound.clip = soundFX[5];
            sound.Play();
            interact.isRadioOn = true;
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
