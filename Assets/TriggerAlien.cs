using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAlien : MonoBehaviour
{
    [SerializeField] private Animator alienAnimator;
    [SerializeField] private GameObject alien;

    // Start is called before the first frame update
    void Start()
    {
        alien.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Debug.Log("trigger enter");
            alien.SetActive(true);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            alien.SetActive(false);
        }
    }
}
