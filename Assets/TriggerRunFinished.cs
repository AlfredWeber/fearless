using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRunFinished : MonoBehaviour
{
    public GameObject door;
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

        EnemyController.Instance.gameObject.SetActive(false);
        AudioManager.Instance.StopSound(Sound.HORROR_RUN);
        Helper.FindChildGameObjectByName(Helper.FindGameObjectByName("GeneratorMain").gameObject, "default").GetComponent<Generator>().canClick = true;
        Animator anim = door.GetComponent<Animator>();
        anim.speed = 5f;
        anim.SetBool("Close", true);
        anim.SetBool("Open", false);
        door.GetComponent<HotelRoomDoor>().SetIsOpen(false);
        AudioManager.Instance.PlaySoundOneShot(Sound.DOOR_CLOSE_LOUD);
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag != "Player") return;
        this.gameObject.SetActive(false);
    }
}
