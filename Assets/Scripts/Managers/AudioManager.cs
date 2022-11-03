using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    private void Update()
    {
        CleanUp();
    }

    private void CleanUp()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = null;
            audioSource.loop = false;
        }
    }

    public void PlaySoundOneShot(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void PlaySoundLoop(AudioClip clip)
    {
        audioSource.loop = true;
        PlaySound(clip);
    }

    public void StopSound()
    {
        audioSource.Stop();
    }
}
