using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoors : MonoBehaviour
{
    private Vector3 targetPosition = new Vector3(0, 0.1f, 20f);
    private Vector3 targetRotation = new Vector3(0, 180f, 0);
    private Vector3 targetScale = new Vector3(0.025f, 0.025f, 0.025f);

    public GameObject exitDoor;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag != "Player") return;

        GameManager.Instance.LockDoors();
        AudioManager.Instance.PlaySound(Sound.HORROR_RUN, new SoundOptions(this.transform.position, loop: true));
        AudioManager.Instance.PlaySoundOneShot(Sound.POWER_DOWN);
        EnemyController.Instance.gameObject.transform.position = targetPosition;
        EnemyController.Instance.gameObject.transform.rotation *= Quaternion.Euler(targetRotation.x, targetRotation.y, targetRotation.z);
        EnemyController.Instance.gameObject.transform.localScale = targetScale;
        EnemyController.Instance.gameObject.SetActive(true);
        EnemyController.Instance.SetCurrentStatus(EnemyController.EnemyStatus.CRAWL);
        GameObject obj = Helper.FindGameObjectByName("TriggerGenerator");
        obj.SetActive(true);
        exitDoor.GetComponent<HotelRoomDoor>().SetLock(false);
    }
}
