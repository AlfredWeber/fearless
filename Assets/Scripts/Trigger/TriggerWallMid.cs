using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWallMid : MonoBehaviour
{
    public AudioSource Scream;
    public GameObject ThePlayer;
    public bool triggered;

    void OnTriggerEnter () {
        Scream.Play();
        triggered = true;
    }
}
