using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    private bool inReach;
    private Vector3 targetPosition = new Vector3(0, 0.1f, 20f);
    private Vector3 targetRotation = new Vector3(0, 180f, 0);
    private Vector3 targetScale = new Vector3(0.025f, 0.025f, 0.025f);

    void Update()
    {
        if (!inReach || !Input.GetKeyDown(KeyCode.E)) return;

        LightsController.Instance.ToggleAllLights();

        EnemyController.Instance.gameObject.transform.position = targetPosition;
        Helper.FindGameObjectByName("TriggerLights2").gameObject.SetActive(true);
        EnemyController.Instance.gameObject.transform.rotation *= Quaternion.Euler(targetRotation.x, targetRotation.y, targetRotation.z);
        EnemyController.Instance.gameObject.transform.localScale = targetScale;
        EnemyController.Instance.gameObject.SetActive(true);
        EnemyController.Instance.SetCurrentStatus(EnemyController.EnemyStatus.CRAWL);
        Helper.FindGameObjectByName("SpotLightRed").gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (!CheckTrigger(collider.gameObject.tag)) return;

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
