using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence_Controller : MonoBehaviour
{
    [SerializeField] private string[] sequenceType = new string[] { "Blackout", "Footsteps", "Shadow", "Scratches", "Radio" };
    [SerializeField] private AudioSource heartBeat;
    private string randSequence;
    private float timeRemain, timeSequence;
    private bool isSequenceStart;

    // Start is called before the first frame update
    void Start()
    {
        timeRemain = 300;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemain > 0)
        {
            timeRemain -= Time.deltaTime;
            if (!isSequenceStart || timeRemain % 60 == 0)
            {
                SequenceStart();
            }
            else if (isSequenceStart)
            {
                timeSequence += Time.deltaTime;
                if (timeSequence >= 70)
                {
                    heartBeat.Play();
                }
                else if (timeSequence >= 90)
                {
                    //mati
                }
            }
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
        timeSequence = 0;
        heartBeat.Stop();
    }

    void NewSequence()
    {

    }

    void BlackoutSequence()
    {

    }

    void FootstepsSequence()
    {

    }

    void ShadowSequence()
    {

    }

    void ScratchesSequence()
    {

    }

    void RadioSequence()
    {

    }
}
