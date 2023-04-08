using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class HotelRoomDoor : MonoBehaviour
{
    [SerializeField] private bool isOpenable = true;
    [SerializeField] private bool isLocked = false;
    [SerializeField] private CollectableItems key = CollectableItems.NONE;
    private bool isOpen;
    private bool inReach;
    private Animator animator;
    private GameObject doorCreak;

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

    private bool hasItem()
    {
        return PlayerController.Instance.HasQuestItem(key);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (!CheckTrigger(collider.gameObject.tag) || !isOpenable) return;

        inReach = true;
        bool hasItem = this.hasItem();
        TextOptions opts = TextOptions.Default;

        if (hasItem && isLocked)
        {
            HUDManager.Instance.ShowText(TextOptions.DOOR_UNLOCK, opts);
        }
        else if (!hasItem && isLocked)
        {
            opts = new TextOptions(color: Color.gray);
            HUDManager.Instance.ShowText(TextOptions.DOOR_LOCKED, opts);
        }
        else
        {
            HUDManager.Instance.ShowText(TextOptions.DOOR_INTERACT, opts);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (!CheckTrigger(collider.gameObject.tag) || !isOpenable) return;
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

        bool hasItem = this.hasItem();

        if (hasItem && isLocked)
        {
            HUDManager.Instance.ShowText(TextOptions.DOOR_INTERACT);
            AudioManager.Instance.PlaySoundOneShot(Sound.DOOR_UNLOCK);
            isLocked = false;
            return;
        }

        if (hasItem || !isLocked)
        {
            if (doorCreak == null)
            {
                isOpen = !isOpen;
                HandleDoorAnimation(isOpen);
                doorCreak = AudioManager.Instance.PlaySoundOneShot(Sound.DOOR_CREAK);
            }
        }
        else if (!hasItem)
        {
            animator.SetTrigger("Locked");
            AudioManager.Instance.PlaySoundOneShot(Sound.DOOR_LOCKED);
        }
    }

    public void SetLock(bool status)
    {
        this.isLocked = status;
    }

    public void SetIsOpen(bool status)
    {
        this.isOpen = status;
    }
}
