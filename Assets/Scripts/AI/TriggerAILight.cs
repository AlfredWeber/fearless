using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAILight : MonoBehaviour
{
    public Light[] lights;

    // Start is called before the first frame update
    void Start()
    {
        SwitchLight(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "AI")
        {
            SwitchLight(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "AI")
        {
            SwitchLight(false);
        }
    }

    void SwitchLight(bool e)
    {
        foreach(Light l in lights)
        {
            l.enabled = e;
        }
    }
}
