using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowersupplyKey : MonoBehaviour, ICollectable
{

    private bool isInReach;
    [SerializeField] private AudioClip pickUpClip;
    [SerializeField] private bool isRandomSpawn = true;
    private static Vector3 defaultSpawn = new Vector3(-8.085f, 1.313f, 4.214f);
    private Vector3[] possibleSpawnPositions = {
        PowersupplyKey.defaultSpawn,
        new Vector3(17, 0, 114),
        new Vector3(4, 0, 94),
        new Vector3(-3, 0, 62),
        new Vector3(10.687f, 0.69f, 4.886f),
        new Vector3(9, 0, 25)
    };

    void Start()
    {
        this.transform.position = GetRandomSpawnPosition();
        this.gameObject.SetActive(false);
    }

    void Update()
    {
        Collect();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Reach")
        {
            isInReach = true;
            HUDManager.Instance.ShowText(TextOptions.PICK_UP);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Reach")
        {
            isInReach = false;
            HUDManager.Instance.HideText();
        }
    }

    #region Interface
    public CollectableItems Name
    {
        get
        {
            return CollectableItems.PowersupplyKey;
        }
    }

    public void Collect()
    {
        if (isInReach && Input.GetKeyDown(KeyCode.E))
        {
            PlayerController.Instance.AddQuestItem(this);
            HUDManager.Instance.HideText();
            AudioManager.Instance.PlaySoundOneShot(Sound.KEY_PICKED_UP);
            Destroy(this.gameObject);
        }
    }
    #endregion Interface

    private Vector3 GetRandomSpawnPosition()
    {
        if (!this.isRandomSpawn) return PowersupplyKey.defaultSpawn;
        return possibleSpawnPositions[Random.Range(0, possibleSpawnPositions.Length)];
    }
}
