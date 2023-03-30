using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLights : MonoBehaviour
{
    [SerializeField] private bool deactivateOnExit;
    private static bool spawnKey = true;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag != "Player") return;

        LightsController.Instance.ToggleAllLights();
        if (spawnKey)
        {
            GameObject key = Helper.FindGameObjectByName("PowersupplyKey");
            if (key == null) Debug.LogError("Powersupply-Key not found!");
            else key.SetActive(true);
            spawnKey = false;
        }

        if (deactivateOnExit) this.gameObject.SetActive(false);
    }
}
