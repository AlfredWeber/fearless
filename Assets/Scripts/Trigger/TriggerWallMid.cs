using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWallMid : MonoBehaviour
{
    public AudioSource Scream;
    public GameObject ThePlayer;
    public bool triggered;
    public AudioSource backgroundSound;

    void OnTriggerEnter(Collider other)
    {
        if (!triggered && other.tag == "Player")
        {
            backgroundSound.Stop();
            // Scream.Play();
            // triggered = true;
            EnemyLevel1.Instance.SetCurrentStatus(EnemyLevel1.EnemyStatus.CRAWL);
        }
    }
}
