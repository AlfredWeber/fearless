using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour
{
    [SerializeField] AudioClip ring;
    [SerializeField] float delayInSeconds = 3f * 60f;
    private bool isRinging;
    private bool inReach;
    private Coroutine hash;
    private SoundOptions soundOptions;

    private void Start()
    {
        hash = StartCoroutine("Ring");
        soundOptions = new SoundOptions(this.transform.position, loop: true);
    }

    private void Update()
    {
        if (inReach && Input.GetKeyDown(KeyCode.E) && isRinging)
        {
            isRinging = false;
            StopCoroutine(hash);
            AudioManager.Instance.StopSound(Sound.TELEPHONE_RING);
            HUDManager.Instance.HideText();
            hash = StartCoroutine("Ring");
        }
        else if (inReach && isRinging) HUDManager.Instance.ShowText(TextOptions.PICK_UP);
    }

    private IEnumerator Ring()
    {
        yield return new WaitForSeconds(delayInSeconds);
        isRinging = true;
        AudioManager.Instance.PlaySound(Sound.TELEPHONE_RING, soundOptions);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Reach")
        {
            inReach = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Reach")
        {
            inReach = false;
            HUDManager.Instance.HideText();
        }
    }
}
