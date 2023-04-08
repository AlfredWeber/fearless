using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextOptions
{
    private static string _interact = "[E]";
    public static string PICK_UP = "Pick up " + _interact;
    public static string DOOR_INTERACT = "Open/Close " + _interact;
    public static string CCTV = "Interact " + _interact;
    public static string READ_NOTE = "Read Note " + _interact;
    public static string DOOR_LOCKED = "Locked " + _interact;
    public static string DOOR_UNLOCK = "Unlock " + _interact;

    public static TextOptions Default = new TextOptions(Color.white, 16);

    public Color color;
    public float fontSize;

    public TextOptions(Color? color = null, float fontSize = 16f)
    {
        this.color = color == null ? Color.white : (Color)color;
        this.fontSize = fontSize;
    }
}
public class ImageOptions
{
    public static RawImage NOTE_LOBBY = Helper
                                            .FindChildGameObjectByName(HUDManager.Instance.gameObject, "NoteLobby")
                                            .GetComponent<RawImage>();
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
        powerSupplyKey = Helper.FindChildGameObjectByName(this.gameObject, "HudPowersupplyKey").GetComponent<RawImage>();
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

    public void SetFlashlight(bool status)
    {

        RawImage flashlightOn = Helper.FindChildGameObjectByName(this.gameObject, "FlashlightOn").GetComponent<RawImage>();
        RawImage flashlightOff = Helper.FindChildGameObjectByName(this.gameObject, "FlashlightOff").GetComponent<RawImage>();
        if (status)
        {
            flashlightOn.enabled = true;
            flashlightOff.enabled = false;
        }
        else
        {
            flashlightOn.enabled = false;
            flashlightOff.enabled = true;
        }


    }

    private void ApplyTextOptions(TextOptions opts = null)
    {
        if (opts == null) opts = TextOptions.Default;
        this.text.color = opts.color;
        this.text.fontSize = opts.fontSize;
    }

    public void ShowText(string text, TextOptions opts = null)
    {
        if (opts != null) ApplyTextOptions(opts);
        this.text.text = text;
        this.text.enabled = true;
    }

    public void HideText()
    {
        ApplyTextOptions(TextOptions.Default);
        this.text.enabled = false;
    }

    public void ShowImage(RawImage image)
    {
        image.enabled = true;
    }

    public void HideImage(RawImage image)
    {
        image.enabled = false;
    }
}
