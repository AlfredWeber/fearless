using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    private bool inReach;
    public bool canClick = true;

    void Update()
    {
        if (!inReach || !Input.GetKeyDown(KeyCode.E) || !canClick) return;

        LightsController.Instance.ToggleAllLights();


        Helper.FindGameObjectByName("TriggerLights2").gameObject.SetActive(true);

        Helper.FindGameObjectByName("SpotLightRed").gameObject.SetActive(true);
        Helper.FindGameObjectByName("PointLightGenerator").gameObject.SetActive(true);
        inReach = false;
        HUDManager.Instance.HideText();
        canClick = false;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (!CheckTrigger(collider.gameObject.tag) || !canClick) return;

        inReach = true;
        TextOptions opts = TextOptions.Default;
        HUDManager.Instance.ShowText(TextOptions.CCTV, opts);
    }

    private void OnTriggerExit(Collider collider)
    {
        if (!CheckTrigger(collider.gameObject.tag)) return;
        inReach = false;
        HUDManager.Instance.HideText();
    }

    private bool CheckTrigger(string tag)
    {
        return tag == "Reach";
    }
}
