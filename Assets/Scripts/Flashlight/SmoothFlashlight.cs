using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFlashlight : MonoBehaviour
{
    private Vector3 vectorOffset;
    private GameObject cameraFollow;
    private bool isActive;
    private Light flashlight;
    private AudioSource flashlightSound;
    private bool isCountdown;
    [SerializeField] private float speed = 3f;

    void Start()
    {
        flashlightSound = GetComponent<AudioSource>();
        flashlight = GetComponent<Light>();
        cameraFollow = Camera.main.gameObject;
        vectorOffset = transform.position - cameraFollow.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cameraFollow.transform.position + vectorOffset;
        transform.rotation = Quaternion.Slerp(transform.rotation, cameraFollow.transform.rotation, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.F) && !isActive)
        {
            HUDManager.Instance.ToggleFlashlight();
            isActive = true;
            flashlight.enabled = isActive;
            flashlightSound.Play();
            if (!isCountdown)
            {
                isCountdown = true;
                StartCoroutine("FlickerFlashlight");
            }
        }
        else if (Input.GetKeyDown(KeyCode.F) && isActive)
        {
            HUDManager.Instance.ToggleFlashlight();
            isActive = false;
            flashlight.enabled = isActive;
            flashlightSound.Play();
            StopCoroutine("FlickerFlashlight");
            isCountdown = false;
        }
    }

    private IEnumerator FlickerFlashlight()
    {
        yield return new WaitForSeconds(5f);

        for (int i = 0; i < 6; i++)
        {
            yield return new WaitForSeconds(0.1f);
            flashlight.enabled = !flashlight.enabled;
        }

        isCountdown = false;
    }
}
