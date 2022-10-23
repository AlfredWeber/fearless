using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private Image customImage;

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
        if(collision.gameObject.tag == "AI")
        {
            customImage.enabled = true;
            StartCoroutine(Reset());
        }
    }
 
}
