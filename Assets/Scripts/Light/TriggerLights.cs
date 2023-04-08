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
        // string text = "Juergen";
        if (PlayerName.Instance != null)
        {
            switch (PlayerName.Instance.playerName)
            {
                case "Daniela":
                    AudioManager.Instance.PlaySoundOneShot(Sound.NAME_DANIELA);
                    break;
                case "Juergen":
                    AudioManager.Instance.PlaySoundOneShot(Sound.NAME_JUERGEN);
                    break;
                case "Simon":
                    AudioManager.Instance.PlaySoundOneShot(Sound.NAME_SIMON);
                    break;
                case "Norbert":
                    AudioManager.Instance.PlaySoundOneShot(Sound.NAME_NORBERT);
                    break;
                case "Nicola":
                    AudioManager.Instance.PlaySoundOneShot(Sound.NAME_NICOLA);
                    break;
                case "Manuel":
                    AudioManager.Instance.PlaySoundOneShot(Sound.NAME_MANUEL);
                    break;
                case "Lorenz":
                    AudioManager.Instance.PlaySoundOneShot(Sound.NAME_LORENZ);
                    break;
                case "Nick":
                    AudioManager.Instance.PlaySoundOneShot(Sound.NAME_NICK);
                    break;
                case "Stefan":
                    AudioManager.Instance.PlaySoundOneShot(Sound.NAME_STEFAN);
                    break;

            }
        }

        if (deactivateOnExit) this.gameObject.SetActive(false);
    }
}
