using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundOptions
{
    public static SoundOptions Default = new SoundOptions(new Vector3(0, 0, 0));

    public bool bypassEffects;
    public bool bypassListenerEffects;
    public bool bypassReverbZones;
    public bool ignoreListenerPause;
    public bool ignoreListenerVolume;
    public bool loop;
    public bool mute;
    public bool playOnAwake;
    public bool spatialize;
    public bool spatializePostEffects;
    public float dopplerLevel;
    public float maxDistance;
    public float minDistance;
    public float panStereo;
    public float pitch;
    public float reverbZoneMix;
    public float spatialBlend;
    public float spread;
    public float time;
    public float volume;
    public int priority;
    public int timeSamples;
    // public GamepadSpeakerOutputType gamepadSpeakerOutputType;
    public AudioMixerGroup outputAudioMixerGroup;
    public AudioRolloffMode rolloffMode;
    public AudioVelocityUpdateMode velocityUpdateMode;
    public Vector3 position;

    // private AudioSource src;
    // private void test()
    // {
    //     AudioSource.
    // }

    public SoundOptions(
        Vector3 position,
        bool bypassEffects = false,
        bool bypassListenerEffects = false,
        bool bypassReverbZones = false,
        bool ignoreListenerPause = false,
        bool ignoreListenerVolume = false,
        bool loop = false,
        bool mute = false,
        bool playOnAwake = false,
        bool spatialize = false,
        bool spatializePostEffects = false,
        float dopplerLevel = 1f,
        float maxDistance = 500f,
        float minDistance = 1f,
        float panStereo = 0f,
        float pitch = 1f,
        float reverbZoneMix = 1f,
        float spatialBlend = 0f,
        float spread = 0f,
        float time = 0f,
        float volume = 1f,
        int priority = 128,
        int timeSamples = 0,
        // GamepadSpeakerOutputType gamepadSpeakerOutputType = GamepadSpeakerOutputType.Speaker,
        AudioMixerGroup outputAudioMixerGroup = null,
        AudioRolloffMode rolloffMode = AudioRolloffMode.Logarithmic,
        AudioVelocityUpdateMode velocityUpdateMode = AudioVelocityUpdateMode.Auto
    )
    {
        if (position == null) position = Vector3.zero;
        this.position = position;
        this.bypassEffects = bypassEffects;
        this.bypassListenerEffects = bypassListenerEffects;
        this.bypassReverbZones = bypassReverbZones;
        this.ignoreListenerPause = ignoreListenerPause;
        this.ignoreListenerVolume = ignoreListenerVolume;
        this.loop = loop;
        this.mute = mute;
        this.playOnAwake = playOnAwake;
        this.spatialize = spatialize;
        this.spatializePostEffects = spatializePostEffects;
        this.dopplerLevel = dopplerLevel;
        this.maxDistance = maxDistance;
        this.minDistance = minDistance;
        this.panStereo = panStereo;
        this.pitch = pitch;
        this.reverbZoneMix = reverbZoneMix;
        this.spatialBlend = spatialBlend;
        this.spread = spread;
        this.time = time;
        this.volume = volume;
        this.priority = priority;
        this.timeSamples = timeSamples;
        // this.gamepadSpeakerOutputType = gamepadSpeakerOutputType;
        this.outputAudioMixerGroup = outputAudioMixerGroup;
        this.rolloffMode = rolloffMode;
        this.velocityUpdateMode = velocityUpdateMode;
    }
}