using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Helper
{
    public static GameObject FindChildGameObjectByName(GameObject parent, string name)
    {
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            if (parent.transform.GetChild(i).name.ToLower() == name.ToLower())
            {
                return parent.transform.GetChild(i).gameObject;
            }

            GameObject tmp = FindChildGameObjectByName(parent.transform.GetChild(i).gameObject, name);

            if (tmp != null)
            {
                return tmp;
            }
        }
        return null;
    }

    public static void FindChildGameObjectsByName(GameObject parent, string name, ref List<GameObject> output)
    {
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            if (parent.transform.GetChild(i).name.ToLower() == name.ToLower())
            {
                output.Add(parent.transform.GetChild(i).gameObject);
            }

            FindChildGameObjectsByName(parent.transform.GetChild(i).gameObject, name, ref output);
        }
    }

    public static void FindChildGameObjectsByNames(GameObject parent, string[] names, ref List<GameObject> output)
    {
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            if (Includes(names, parent.transform.GetChild(i).name.ToLower()))
            {
                output.Add(parent.transform.GetChild(i).gameObject);
            }

            FindChildGameObjectsByNames(parent.transform.GetChild(i).gameObject, names, ref output);
        }
    }

    public static void FindAllMaterials(GameObject parent, ref List<Material> output)
    {
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            MeshRenderer mr = parent.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>();

            if (mr != null)
            {
                foreach (Material m in mr.materials)
                {
                    output.Add(m);
                }
            }

            FindAllMaterials(parent.transform.GetChild(i).gameObject, ref output);
        }
    }

    private static bool Includes(Material[] list, string name)
    {
        foreach (Material m in list)
        {
            if (m.name.ToLower() == name.ToLower()) return true;
        }

        return false;
    }

    private static bool Includes(string[] arr, string target)
    {
        foreach (string s in arr)
        {
            if (s.ToLower() == target) return true;
        }

        return false;
    }


}
