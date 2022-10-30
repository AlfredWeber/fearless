using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLights : MonoBehaviour
{
    private LightsController lightsController;

    [SerializeField] private bool deactivateOnExit;
    void Start()
    {
        lightsController = new LightsController();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag != "Player") return;
        lightsController.ToggleAllLights(false);

        if (deactivateOnExit) this.enabled = false;
    }
}
