using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTriggerSound : MonoBehaviour
{
    public bool triggered = false;
    public string colliderTag = "Player";

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (!triggered && other.tag == colliderTag)
        {
            triggered = true;
            GetComponent<AudioSource>().Play();
        }
    }
}
