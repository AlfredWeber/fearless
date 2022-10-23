using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;


public class Keypad : MonoBehaviour
{
    public GameObject player;
    public GameObject keypadOB;
    public GameObject hud;
    // public GameObject inv;


    public GameObject animateOB;
    public Animator ANI;


    public Text textOB;
    public string answer = "12345";

    public AudioSource button;
    public AudioSource correct;
    public AudioSource wrong;

    void Start()
    {
        keypadOB.SetActive(true);
    }


    public void Number(int number)
    {
        textOB.text += number.ToString();
        button.Play();
    }

    public void Execute()
    {
        if (textOB.text == answer)
        {
            correct.Play();
            textOB.text = "Right";

        }
        else
        {
            wrong.Play();
            textOB.text = "Wrong";
        }


    }

    public void Clear()
    {
        {
            textOB.text = "";
            button.Play();
        }
    }

    public void Exit()
    {
        keypadOB.SetActive(false);
        // inv.SetActive(true);
        hud.SetActive(true);
        player.GetComponent<FirstPersonController>().enabled = true;
        Rigidbody playerRigid = player.GetComponent<Rigidbody>();
        playerRigid.constraints = RigidbodyConstraints.None;
    }

    public void Update()
    {
        if (textOB.text == "Right")
        {
            ANI.SetBool("Open", true);
            Exit();
        }

        if(keypadOB.activeInHierarchy)
        {
            hud.SetActive(false);
            // inv.SetActive(false);
            player.GetComponent<FirstPersonController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

    }


}
