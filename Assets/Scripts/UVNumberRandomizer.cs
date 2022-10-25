using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVNumberRandomizer : MonoBehaviour
{
    public GameObject[] numbers = new GameObject[3];
    public GameObject player, keypadOB;

    // Start is called before the first frame update
    void Start()
    {
        SetAlbedos();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetAlbedos()
    {
        Flashlight f = player.GetComponent<Flashlight>();
        Keypad k = keypadOB.GetComponent<Keypad>();
        k.answer = "";
        int i = 1;
        foreach (GameObject o in numbers)
        {
            int number = Random.Range(1, 9);
            k.answer = number.ToString() + k.answer;
            string s = "Number" + number + "Transparent";
            Texture2D t = Resources.Load(s) as Texture2D;
            Material m = o.GetComponent<Renderer>().material;
            m.SetTexture("_MainTex", t);
            f.MatList[i] = m;
            i++;
        }
    }
}
