using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Sound
{
    TELEPHONE_RING,
    KEY_PICKED_UP,
    CLOCK_TICKING,
    DOOR_CREAK,
    DOOR_LOCKED,
    DOOR_UNLOCK,
    HORROR_RUN,
    POWER_DOWN,
    DOOR_CLOSE_LOUD,
    SCREAM
}

[System.Serializable]
public class SoundAudioClip
{
    public Sound sound;
    public AudioClip clip;
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    [SerializeField] private List<SoundAudioClip> mappedAudioClips;
    private List<GameObject> musicGameObjects;
    private List<GameObject> soundEffectGameObjects;
    private bool isCoroutineRunning;

    #region Unity lifecycle
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        musicGameObjects = new List<GameObject>();
        soundEffectGameObjects = new List<GameObject>();
    }

    private void Update()
    {
        if (!isCoroutineRunning)
        {
            isCoroutineRunning = true;
            StartCoroutine(DeleteOneShotGameObjects());
        }
    }
    #endregion Unity lifecycle



    private void SetSoundOptions(ref AudioSource src, SoundOptions opts)
    {
        if (opts == null) return;

        src.bypassEffects = opts.bypassEffects;
        src.bypassListenerEffects = opts.bypassListenerEffects;
        src.bypassReverbZones = opts.bypassReverbZones;
        src.ignoreListenerPause = opts.ignoreListenerPause;
        src.ignoreListenerVolume = opts.ignoreListenerVolume;
        src.loop = opts.loop;
        src.mute = opts.mute;
        src.playOnAwake = opts.playOnAwake;
        src.spatialize = opts.spatialize;
        src.spatializePostEffects = opts.spatializePostEffects;
        src.dopplerLevel = opts.dopplerLevel;
        src.maxDistance = opts.maxDistance;
        src.minDistance = opts.minDistance;
        src.panStereo = opts.panStereo;
        src.pitch = opts.pitch;
        src.reverbZoneMix = opts.reverbZoneMix;
        src.spatialBlend = opts.spatialBlend;
        src.spread = opts.spread;
        src.time = opts.time;
        src.volume = opts.volume;
        src.priority = opts.priority;
        src.timeSamples = opts.timeSamples;
        src.gamepadSpeakerOutputType = opts.gamepadSpeakerOutputType;
        src.outputAudioMixerGroup = opts.outputAudioMixerGroup;
        src.rolloffMode = opts.rolloffMode;
        src.velocityUpdateMode = opts.velocityUpdateMode;
        src.gameObject.transform.position = opts.position;
    }

    private GameObject CreateGameobjectWithAudiosource(Sound sound, bool isPlay, SoundOptions opts = null)
    {
        // Look up audioclip and return if not found
        AudioClip clip = FindAudioClip(sound);
        if (clip == null)
        {
            Debug.LogError("Sound-Clip not found!");
            return null;
        }

        // Create new Gameobject with Audiosource attached
        GameObject go;
        if (isPlay) go = new GameObject("Music-" + clip.name + "-" + musicGameObjects.Count);
        else go = new GameObject("Effect-" + clip.name + "-" + soundEffectGameObjects.Count);
        AudioSource audioSource = go.AddComponent<AudioSource>();

        // Assign audio-clip
        audioSource.clip = clip;

        // Apply position & other options for Audiosource
        SetSoundOptions(ref audioSource, opts);

        if (soundEffectGameObjects == null && !isPlay)
        {
            Debug.LogError("FX-List not initialized yet!");
            return null;
        }

        // Insert Gameobject into list
        if (isPlay) musicGameObjects.Add(go);
        else soundEffectGameObjects.Add(go);

        // return newly created audiosrc
        return go;
    }

    private GameObject ExistsMusic(Sound sound)
    {
        if (musicGameObjects == null)
        {
            Debug.LogError("Music-List not initialized yet!");
            return null;
        }

        for (int i = 0; i < musicGameObjects.Count; i++)
        {
            AudioSource audioSource = musicGameObjects[i].GetComponent<AudioSource>();
            foreach (SoundAudioClip sac in mappedAudioClips)
            {
                if (sound == sac.sound && sac.clip == audioSource.clip) return musicGameObjects[i];
            }
        }

        return null;
    }

    private IEnumerator DeleteOneShotGameObjects()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < soundEffectGameObjects.Count; i++)
        {
            GameObject go = soundEffectGameObjects[i];
            AudioSource audioSource = go.GetComponent<AudioSource>();
            if (!audioSource.isPlaying)
            {
                Destroy(go);
                soundEffectGameObjects.Remove(go);
            }
        }

        isCoroutineRunning = false;
    }

    private GameObject FindBySound(Sound sound)
    {
        for (int i = 0; i < musicGameObjects.Count; i++)
        {
            AudioSource audioSource = musicGameObjects[i].GetComponent<AudioSource>();
            foreach (SoundAudioClip sac in mappedAudioClips)
            {
                if (sound == sac.sound && sac.clip == audioSource.clip)
                {
                    return musicGameObjects[i];
                }
            }
        }

        for (int i = 0; i < soundEffectGameObjects.Count; i++)
        {
            AudioSource audioSource = soundEffectGameObjects[i].GetComponent<AudioSource>();
            foreach (SoundAudioClip sac in mappedAudioClips)
            {
                if (sound == sac.sound && sac.clip == audioSource.clip)
                {
                    return soundEffectGameObjects[i];
                }
            }
        }

        return null;
    }


    public void Restart()
    {
        musicGameObjects = new List<GameObject>();
        soundEffectGameObjects = new List<GameObject>();
    }

    public AudioClip FindAudioClip(Sound sound)
    {
        SoundAudioClip a = mappedAudioClips.Find((sac) => sac.sound == sound);
        if (a == null) return null;
        else return a.clip;
    }

    public GameObject PlaySoundOneShot(Sound sound, SoundOptions opts = null)
    {
        // Set up everything
        GameObject go = CreateGameobjectWithAudiosource(sound, false, opts);
        AudioSource audioSource = go.GetComponent<AudioSource>();

        // Finally play clip one shot 
        audioSource.PlayOneShot(audioSource.clip);
        return go;
    }

    public GameObject PlaySound(Sound sound, SoundOptions opts = null)
    {
        // If Gameobject already exists, use it. Else set up everything
        GameObject go = ExistsMusic(sound);
        if (go == null) go = CreateGameobjectWithAudiosource(sound, true, opts);

        AudioSource audioSource = go.GetComponent<AudioSource>();

        // Finally play clip one shot 
        audioSource.Play();
        return go;
    }

    public void StopSound(Sound sound)
    {
        GameObject go = FindBySound(sound);
        if (go == null) return;
        AudioSource src = go.GetComponent<AudioSource>();
        if (src == null) return;
        src.Stop();
    }

    public bool HasFinished(GameObject go)
    {
        if (go == null) return false;
        AudioSource src = go.GetComponent<AudioSource>();
        if (src == null) return false;
        return !src.isPlaying;
    }

    public bool HasFinished(string name)
    {
        GameObject go = null;
        bool found = false;

        for (int i = 0; i < soundEffectGameObjects.Count && !found; i++)
        {
            GameObject tmp = soundEffectGameObjects[i];
            if (tmp.name == name)
            {
                found = true;
                go = tmp;
            }
        }

        for (int i = 0; i < musicGameObjects.Count && !found; i++)
        {
            GameObject tmp = musicGameObjects[i];
            if (tmp.name == name)
            {
                found = true;
                go = tmp;
            }
        }

        return HasFinished(go);
    }

    public bool HasFinished(Sound sound)
    {
        return HasFinished(FindBySound(sound));
    }
}
