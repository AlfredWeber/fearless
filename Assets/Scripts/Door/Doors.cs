using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    private Animator animator;
    public GameObject openText;
    public AudioSource doorSound;
    public bool inReach;
    private bool isOpen;

    void Start()
    {
        animator = GetComponent<Animator>();
        inReach = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            openText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            openText.SetActive(false);
        }
    }

    void Update()
    {
        if (inReach && Input.GetButtonDown("Interact") && !isOpen)
        {
            isOpen = true;
            DoorOpens();
        }

        else if (inReach && Input.GetButtonDown("Interact") && isOpen)
        {
            isOpen = false;
            DoorCloses();
        }

    }
    void DoorOpens()
    {
        animator.SetBool("Open", true);
        animator.SetBool("Close", false);
        doorSound.Play();

    }

    void DoorCloses()
    {
        animator.SetBool("Open", false);
        animator.SetBool("Close", true);
        doorSound.Play();
    }


}
