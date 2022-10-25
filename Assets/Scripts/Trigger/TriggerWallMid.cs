using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWallMid : MonoBehaviour
{
    public AudioSource Scream;
    public GameObject ThePlayer;
    public bool triggered;
    public AudioSource backgroundSound;

    void OnTriggerEnter()
    {
        if (!triggered)
        {
            backgroundSound.Stop();
            // Scream.Play();
            triggered = true;
        }
    }
}
