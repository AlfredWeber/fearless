using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Flashlight : MonoBehaviour
{
    public GameObject flashlight;

    public AudioSource turnOn;
    public AudioSource turnOff;

    public bool on;
    public bool off;
    private bool UV;

    private Color standartColor;
    private Light lightComp;

    [SerializeField] public Material[] MatList = new Material[4];
    [SerializeField] Light SpotLight;

    void Start()
    {
        lightComp = flashlight.GetComponent<Light>();
        standartColor = flashlight.GetComponent<Light>().color;
        off = true;
        flashlight.SetActive(false);
    }

    void Update()
    {
        // Mat && SpotLight &&
        if (UV)
        {
            foreach (Material mat in MatList)
            {
                mat.SetVector("_LightPosition", SpotLight.transform.position);
                mat.SetVector("_LightDirection", -SpotLight.transform.forward);
                mat.SetFloat("_LightAngle", SpotLight.spotAngle);
            }
        }
        else
        {
            foreach (Material mat in MatList)
            {
                mat.SetFloat("_LightAngle", 0f);
            }
        }

        if (off && Input.GetButtonDown("F"))
        {
            UV = false;
            lightComp.color = standartColor;
            lightComp.intensity = 1f;
            lightComp.spotAngle = 55f;
            flashlight.SetActive(true);
            turnOn.Play();
            off = false;
            on = true;
        }
        else if (on && Input.GetButtonDown("F"))
        {
            UV = false;
            flashlight.SetActive(false);
            turnOff.Play();
            off = true;
            on = false;
        }
        else if (off && Input.GetButtonDown("R"))
        {
            UV = true;
            lightComp.color = Color.magenta;
            lightComp.intensity = 1f;
            lightComp.spotAngle = 35f;
            flashlight.SetActive(true);
            turnOn.Play();
            off = false;
            on = true;
        }
        else if (on && Input.GetButtonDown("R"))
        {
            UV = false;
            flashlight.SetActive(false);
            turnOff.Play();
            off = true;
            on = false;
        }
    }
}
