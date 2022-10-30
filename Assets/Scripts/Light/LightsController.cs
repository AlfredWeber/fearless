using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsController
{
    private GameObject[] lightParents;

    public LightsController()
    {
        lightParents = GetAllLightParents();
    }

    public void ToggleAllLights(bool active)
    {
        foreach (GameObject go in lightParents)
        {
            go.SetActive(active);
        }
    }

    private GameObject[] GetAllLightParents()
    {
        return GameObject.FindGameObjectsWithTag("LightParent");
    }
}
