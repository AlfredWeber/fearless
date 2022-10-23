using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalControler : MonoBehaviour
{
    public GameObject pressTerminalText;
    public bool inReach;
    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            pressTerminalText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            pressTerminalText.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inReach && Input.GetButtonDown("Interact"))
        {
            TerminalPressed();
        }
    }

    void TerminalPressed ()
    {
        
    }
}
