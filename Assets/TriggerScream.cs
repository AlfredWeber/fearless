using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScream : MonoBehaviour
{
    public GameObject exitDoor;
    public GameObject hotelDoor;
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

        AudioManager.Instance.PlaySoundOneShot(Sound.SCREAM, new SoundOptions(position: this.transform.position, volume: 5f));
        this.gameObject.SetActive(false);
        exitDoor.GetComponent<HotelRoomDoor>().SetLock(false);
        Animator anim = hotelDoor.GetComponent<Animator>();
        anim.speed = 1f;
    }
}
