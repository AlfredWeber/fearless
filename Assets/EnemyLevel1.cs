using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyLevel1 : MonoBehaviour
{
    public static EnemyLevel1 Instance { get; private set; }
    private Animator animator;
    public enum EnemyStatus { IDLE, CRAWL };
    private EnemyStatus currentEnemyStatus = EnemyStatus.IDLE;
    private bool soundPlayed = false;
    private NavMeshAgent enemy;
    public GameObject playerObj;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        enemy = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (currentEnemyStatus == EnemyStatus.CRAWL)
        {
            if (!animator.GetBool("isCrawling")) animator.SetBool("isCrawling", true);
            Instance.enemy.SetDestination(new Vector3(playerObj.transform.position.x, 0, playerObj.transform.position.z));
            Instance.gameObject.transform.LookAt(playerObj.transform);
            Instance.gameObject.transform.rotation *= Quaternion.Euler(new Vector3(0, 180f, 0));
            Instance.gameObject.GetComponent<CapsuleCollider>().radius = 20;
            Instance.gameObject.GetComponent<CapsuleCollider>().height = 120;
            if (!soundPlayed)
            {
                Instance.gameObject.GetComponent<AudioSource>().Play();
                soundPlayed = true;
            }
        }
    }

    public void SetCurrentStatus(EnemyStatus status)
    {
        currentEnemyStatus = status;
    }
}
