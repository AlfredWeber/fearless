using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoors : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag != "Player") return;

        GameManager.Instance.LockDoors();
        AudioManager.Instance.PlaySoundOneShot(Sound.HORROR_RUN);
    }
}
