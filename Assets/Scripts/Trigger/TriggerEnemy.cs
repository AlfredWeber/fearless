using System.Collections;
using UnityEngine;

public class TriggerEnemy : MonoBehaviour
{
    [SerializeField] private Vector3 targetPosition = new Vector3(0, 0, 0);
    [SerializeField] private Vector3 targetRotation = new Vector3(0, 0, 0);
    [SerializeField] private Vector3 targetScale = new Vector3(0, 0, 0);
    [SerializeField] private bool deactivateOnExit;

    private GameObject enemy;
    private GameObject player;
    private Vector3 originPosition;
    private Quaternion originRotation;
    private Vector3 originScale;
    private bool isStaring;
    private Coroutine coroutine;

    private void Start()
    {
        enemy = EnemyController.Instance.gameObject;
        player = UnityStandardAssets.Characters.FirstPerson.FirstPersonController.Instance.gameObject;
        InitializeOrigin();
        enemy.SetActive(false);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (!CheckCollider(collider)) return;

        enemy.transform.position = targetPosition;
        enemy.transform.rotation *= Quaternion.Euler(targetRotation.x, targetRotation.y, targetRotation.z);
        enemy.transform.localScale = targetScale;
        enemy.SetActive(true);
        coroutine = StartCoroutine(BeginChase());
    }

    private void OnTriggerExit(Collider collider)
    {
        if (!CheckCollider(collider)) return;

        if (deactivateOnExit) this.gameObject.SetActive(false);
        enemy.transform.position = originPosition;
        enemy.transform.rotation = originRotation;
        enemy.transform.localScale = originScale;
        enemy.SetActive(false);
    }

    private void OnTriggerStay(Collider collider)
    {
        if (!CheckCollider(collider)) return;

        if (coroutine == null && isStaring) coroutine = StartCoroutine(BeginChase());
        else if (coroutine != null && !isStaring)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
    }

    private void Update()
    {
        float currentView;
        if (player.transform.rotation.eulerAngles.y > 180) currentView = (360 - player.transform.rotation.eulerAngles.y) * -1;
        else currentView = player.transform.rotation.eulerAngles.y;
        isStaring = (currentView > -90f && currentView < 90f);
    }

    private IEnumerator BeginChase()
    {
        yield return new WaitForSeconds(5f);
        EnemyController.Instance.SetCurrentStatus(EnemyController.EnemyStatus.CRAWL_KILL);
        this.gameObject.SetActive(false);
    }

    private bool CheckCollider(Collider collider)
    {
        return collider.tag == "Player";
    }

    private void InitializeOrigin()
    {
        originPosition = enemy.transform.position;
        originRotation = enemy.transform.rotation;
        originScale = enemy.transform.localScale;
    }
}
