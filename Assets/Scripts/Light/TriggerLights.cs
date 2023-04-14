using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLights : MonoBehaviour
{
    [SerializeField] private bool deactivateOnExit;
    public static bool spawnKey = true;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag != "Player") return;

        LightsController.Instance.ToggleAllLights();
        if (spawnKey)
        {
            AudioManager.Instance.PlaySoundOneShot(Sound.POWER_DOWN);
            GameObject key = Helper.FindGameObjectByName("PowersupplyKey");
            if (key == null) Debug.LogError("Powersupply-Key not found!");
            else key.SetActive(true);
            spawnKey = false;
        }
    }

    private void OnTriggerExit()
    {
        if (PlayerName.Instance != null)
        {
            string name = PlayerName.Instance.playerName.ToLower();
            switch (name)
            {
                case "daniela":
                    AudioManager.Instance.PlaySoundOneShot(Sound.NAME_DANIELA);
                    break;
                case "juergen":
                    AudioManager.Instance.PlaySoundOneShot(Sound.NAME_JUERGEN);
                    break;
                case "jürgen":
                    AudioManager.Instance.PlaySoundOneShot(Sound.NAME_JUERGEN);
                    break;
                case "simon":
                    AudioManager.Instance.PlaySoundOneShot(Sound.NAME_SIMON);
                    break;
                case "norbert":
                    AudioManager.Instance.PlaySoundOneShot(Sound.NAME_NORBERT);
                    break;
                case "nicola":
                    AudioManager.Instance.PlaySoundOneShot(Sound.NAME_NICOLA);
                    break;
                case "manuel":
                    AudioManager.Instance.PlaySoundOneShot(Sound.NAME_MANUEL);
                    break;
                case "lorenz":
                    AudioManager.Instance.PlaySoundOneShot(Sound.NAME_LORENZ);
                    break;
                case "nick":
                    AudioManager.Instance.PlaySoundOneShot(Sound.NAME_NICK);
                    break;
                case "stefan":
                    AudioManager.Instance.PlaySoundOneShot(Sound.NAME_STEFAN);
                    break;
                case "nico":
                    AudioManager.Instance.PlaySoundOneShot(Sound.NAME_NICO);
                    break;
            }
        }

        if (deactivateOnExit) this.gameObject.SetActive(false);
    }
}
