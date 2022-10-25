using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;

public class ButtonDontTouch : MonoBehaviour
{
    public Animator button;
    public GameObject pressButtonText;

    public AudioSource buttonSound;

    [SerializeField] private Image customImage;

    public bool inReach;
    private bool seen = false;

    // Testing

    private AudioSource source;
    public AudioClip Clip;
    public AudioSource backgroundSound;

    void Start()
    {
        inReach = false;
        customImage.enabled = false;
        source = gameObject.AddComponent<AudioSource>();
        source.playOnAwake = false;
        source.clip = Clip;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            pressButtonText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            pressButtonText.SetActive(false);
        }
    }

    void Update()
    {
        if (inReach && Input.GetButtonDown("Interact"))
        {
            ButtonPressed();
        }

        else
        {
            button.SetBool("ButtonPressed", false);
        }
    }

    void ButtonPressed()
    {
        if (!source.isPlaying && !seen)
        {
            backgroundSound.Stop();
            seen = true;
            button.SetBool("ButtonPressed", true);
            source.Play();
            customImage.enabled = true;
            StartCoroutine(StartCountdown());
        }
    }

    public IEnumerator StartCountdown()
    {
        yield return new WaitForSeconds(0.6f);
        customImage.enabled = false;
        backgroundSound.Play();
    }
}
