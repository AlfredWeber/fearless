using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsController : MonoBehaviour
{
    private string[] allLights = { "Point Light", "Spotlight", "Directional Light", "Area Light" };
    private Material[] materials;
    private Dictionary<Material, Color> defaultEmissions;
    private GameObject lightParent;

    public static LightsController Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void Start()
    {
        lightParent = GameObject.Find("Lights").gameObject;
        defaultEmissions = new Dictionary<Material, Color>();
        InitializeDefaultEmissions();
    }

    private void InitializeDefaultEmissions()
    {
        List<Material> materials = new List<Material>();
        Helper.FindAllMaterials(lightParent, ref materials);
        for (int i = 0; i < materials.Count; i++)
        {
            Material material = materials[i];
            if (material.GetColor("_EmissionColor") != Color.black)
            {
                defaultEmissions.Add(material, material.GetColor("_EmissionColor"));
            }
        }
    }

    public void ToggleAllLights()
    {
        List<GameObject> all = new List<GameObject>();
        Helper.FindChildGameObjectsByNames(lightParent, allLights, ref all);
        foreach (var item in all)
        {
            bool isActive = item.GetComponent<Light>().enabled;
            item.GetComponent<Light>().enabled = !isActive;

            foreach (KeyValuePair<Material, Color> kvp in defaultEmissions)
            {
                if (!isActive) kvp.Key.SetColor("_EmissionColor", kvp.Value);
                else kvp.Key.SetColor("_EmissionColor", Color.black);
            }
        }
    }
}
