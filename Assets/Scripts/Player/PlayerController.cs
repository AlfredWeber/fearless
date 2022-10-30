using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController UnityFPSController { get; private set; }
    public static PlayerController Instance { get; private set; }

    private List<ICollectable> questItems;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        UnityFPSController = GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
    }

    private void Start()
    {
        questItems = new List<ICollectable>();
    }

    public void AddQuestItem(ICollectable item)
    {
        questItems.Add(item);
    }

    public bool HasQuestItem(CollectableItems item)
    {
        foreach (ICollectable qi in questItems)
        {
            if (qi.Name == item) return true;
        }

        return false;
    }
}
