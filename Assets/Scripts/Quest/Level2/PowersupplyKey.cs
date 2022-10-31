using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowersupplyKey : MonoBehaviour, ICollectable
{
    private Vector3[] possibleSpawnPositions = {
        new Vector3(17, 0, 114),
        new Vector3(4, 0, 94),
        new Vector3(-3, 0, 62),
        new Vector3(-8.085f, 1.313f, 4.214f),
        new Vector3(10.687f, 0.69f, 4.886f),
        new Vector3(9, 0, 25)
    };
    private bool isInReach;
    [SerializeField] private AudioClip pickUpClip;

    void Start()
    {
        this.transform.position = GetRandomSpawnPosition();
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
            HUDManager.Instance.ShowText(HUDManager.TextDictionary[TextOptions.PICK_UP]);
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
            AudioManager.Instance.PlaySound(pickUpClip);
            Destroy(this.gameObject);
        }
    }
    #endregion Interface

    private Vector3 GetRandomSpawnPosition()
    {
        return possibleSpawnPositions[Random.Range(0, possibleSpawnPositions.Length)];
    }
}
