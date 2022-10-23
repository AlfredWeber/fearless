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
 
    public double stopwatchDifference;
 
    private bool measuring = false;
 
    private Stopwatch _stopWatch;
     
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
        if (measuring == true && (source.timeSamples != 0))
        {
            measuring = false;
            _stopWatch.Stop();
            stopwatchDifference = _stopWatch.Elapsed.TotalSeconds;
        }
        if (inReach && Input.GetButtonDown("Interact"))
        {
            ButtonPressed();
        }

        else
        {
            button.SetBool("ButtonPressed", false);
        }
    }

    void ButtonPressed ()
    {
        if (!source.isPlaying && !seen)
        {
            seen = true;
            button.SetBool("ButtonPressed", true);
            _stopWatch = Stopwatch.StartNew();
            source.Play();
            measuring = true;
            customImage.enabled = true;
            StartCoroutine(StartCountdown()); 
        }
    }

    public IEnumerator StartCountdown()
    {
        yield return new WaitForSeconds(0.6f);
        customImage.enabled = false;         
    }
}
