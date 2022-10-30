//TODO: REWORK WITH PlayerController

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private Image customImage;
    public GameObject keypadGUI;
    public AudioSource gotchyaSound;
    public AudioSource chaseSound;

    void Start()
    {
        customImage.enabled = false;
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(2);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "AI")
        {
            chaseSound.Stop();
            gotchyaSound.PlayOneShot(gotchyaSound.clip);
            keypadGUI.GetComponent<Keypad>().Exit();
            customImage.enabled = true;
            StartCoroutine(Reset());
        }
    }

}
