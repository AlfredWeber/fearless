using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public List<GameObject> doorsDontLock = new List<GameObject>();
    private GameObject doorParent;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void Start()
    {
        doorParent = GameObject.Find("Doors").gameObject;
    }
    public IEnumerator Reset()
    {
        // yield return new WaitForSeconds(2);
        yield return null;
        AudioManager.Instance.Restart();
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    private bool shouldLock(GameObject pivot)
    {
        for (int i = 0; i < doorsDontLock.Count; i++)
        {
            if (doorsDontLock[i].gameObject.Equals(pivot.gameObject)) return false;
        }

        return true;
    }

    public void LockDoors()
    {
        List<GameObject> all = new List<GameObject>();
        Helper.FindChildGameObjectsByName(doorParent, "Pivot", ref all);
        foreach (var item in all)
        {
            if (shouldLock(item)) item.GetComponent<HotelRoomDoor>().SetLock(true);

        }
    }
}