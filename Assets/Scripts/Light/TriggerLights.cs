using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLights : MonoBehaviour
{
    [SerializeField] private bool deactivateOnExit;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag != "Player") return;
        LightsController.Instance.ToggleAllLights();

        if (deactivateOnExit) this.gameObject.SetActive(false);
    }
}
