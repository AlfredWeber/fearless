using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleHallwaylight : MonoBehaviour
{
    [SerializeField] private bool isActive;
    private Material[] materials;
    private Material targetMaterial;
    private Color defaultEmissionColor = new Color(0.251f, 0.251f, 0.251f, 1.000f);
    private Light lightChild;

    private void Start()
    {
        materials = GetComponent<MeshRenderer>().materials;
        lightChild = this.GetComponentInChildren<Light>();
        targetMaterial = GetMaterialByName("gloss1 (Instance)");
        Toggle();
    }

    private Material GetMaterialByName(string name)
    {
        foreach (Material material in materials)
        {
            if (material.name == name) return material;
        }

        return null;
    }

    private void Toggle()
    {
        if (isActive) targetMaterial.SetColor("_EmissionColor", defaultEmissionColor);
        else targetMaterial.SetColor("_EmissionColor", Color.black);
        lightChild.enabled = isActive;
    }
}
