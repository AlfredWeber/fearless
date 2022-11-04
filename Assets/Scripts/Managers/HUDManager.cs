using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextOptions
{
    public static string PICK_UP = "Pick up [E]";
    public static string OPEN_DOOR = "Open/Close [E]";
    public static string CCTV = "Interact [E]";
}

public class HUDManager : MonoBehaviour
{
    public static HUDManager Instance { get; private set; }
    private RawImage powerSupplyKey;
    private TextMeshProUGUI text;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        powerSupplyKey = Helper.FindChildGameObjectByName(this.gameObject, "Key").GetComponent<RawImage>();
        text = Helper.FindChildGameObjectByName(this.gameObject, "InteractionText").GetComponent<TextMeshProUGUI>();
        HideText();
    }

    private void Update()
    {
        if (PlayerController.Instance.HasQuestItem(CollectableItems.PowersupplyKey) && !powerSupplyKey.enabled)
        {
            powerSupplyKey.enabled = true;
        }
    }

    public void ToggleFlashlight()
    {
        RawImage flashlightOn = Helper.FindChildGameObjectByName(this.gameObject, "FlashlightOn").GetComponent<RawImage>();
        RawImage flashlightOff = Helper.FindChildGameObjectByName(this.gameObject, "FlashlightOff").GetComponent<RawImage>();

        flashlightOn.enabled = !flashlightOn.enabled;
        flashlightOff.enabled = !flashlightOff.enabled;
    }

    public void ShowText(string text)
    {
        this.text.text = text;
        this.text.enabled = true;
    }

    public void HideText()
    {
        this.text.enabled = false;
    }
}
