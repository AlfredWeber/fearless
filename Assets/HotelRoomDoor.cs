using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotelRoomDoor : MonoBehaviour
{
    [SerializeField] private bool isOpenable;
    [SerializeField] private bool unLocked;
    private bool isOpen;
    private bool inReach;
    private Animator animator;

    #region Unity life-cycle
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        if (!isOpenable) return;
        HandleDoor();
    }
    #endregion Unity life-cycle

    private void OnTriggerEnter(Collider collider)
    {
        if (!CheckTrigger(collider.gameObject.tag)) return;
        inReach = true;
        HUDManager.Instance.ShowText(TextOptions.OPEN_DOOR);
    }

    private void OnTriggerExit(Collider collider)
    {
        if (!CheckTrigger(collider.gameObject.tag)) return;
        inReach = false;
        HUDManager.Instance.HideText();
    }

    private bool CheckTrigger(string tag)
    {
        return tag == "Reach";
    }

    private void HandleDoorAnimation(bool open)
    {
        animator.SetBool("Open", open);
        animator.SetBool("Close", !open);
    }

    public void HandleDoor()
    {
        if (!inReach || !Input.GetKeyDown(KeyCode.E)) return;
        bool hasQuestItem = PlayerController.Instance.HasQuestItem(CollectableItems.PowersupplyKey);

        if (hasQuestItem && !unLocked)
        {
            unLocked = true;
            AudioManager.Instance.PlaySoundOneShot(Sound.DOOR_UNLOCK);
            return;
        }

        if (hasQuestItem || unLocked)
        {
            isOpen = !isOpen;
            HandleDoorAnimation(isOpen);
            AudioManager.Instance.PlaySoundOneShot(Sound.DOOR_CREAK);
        }
        else if (!hasQuestItem)
        {
            animator.SetTrigger("Locked");
            AudioManager.Instance.PlaySoundOneShot(Sound.DOOR_LOCKED);
        }
    }
}
