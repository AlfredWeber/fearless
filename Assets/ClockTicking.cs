using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockTicking : MonoBehaviour
{
    SoundOptions soundOptions;
    void Start()
    {
        soundOptions = new SoundOptions(
            this.transform.position,
            loop: true,
            spatialize: true,
            spatialBlend: 1f,
            rolloffMode: AudioRolloffMode.Linear,
            minDistance: 1f,
            maxDistance: 9.25f
        );
        AudioManager.Instance.PlaySound(Sound.CLOCK_TICKING, soundOptions);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
