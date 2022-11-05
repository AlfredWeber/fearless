using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Note : MonoBehaviour
{
    private bool inReach;

    private void Update()
    {
        if (inReach && Input.GetKeyDown(KeyCode.E))
        {
            HUDManager.Instance.ShowImage(ImageOptions.LOBBY_NOTE);
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Reach")
        {
            inReach = true;
            HUDManager.Instance.ShowText(TextOptions.READ_NOTE);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Reach")
        {
            inReach = false;
            HUDManager.Instance.HideText();
            HUDManager.Instance.HideImage(ImageOptions.LOBBY_NOTE);
        }
    }
}