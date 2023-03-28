using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public static EnemyController Instance { get; private set; }
    private Animator animator;
    public enum EnemyStatus { IDLE, CRAWL, CRAWL_KILL };
    private EnemyStatus currentEnemyStatus = EnemyStatus.IDLE;
    private float crawlKillSpeed = 15f;
    private bool kill;
    private NavMeshAgent enemy;
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
        if (currentEnemyStatus == EnemyStatus.CRAWL_KILL)
        {
            if (!animator.GetBool("isCrawling")) animator.SetBool("isCrawling", true);
            MoveTowardsPlayer(true);
        }
        else if (currentEnemyStatus == EnemyStatus.CRAWL)
        {
            if (!animator.GetBool("isCrawling")) animator.SetBool("isCrawling", true);
            enemy.SetDestination(new Vector3(PlayerController.Instance.transform.position.x, 0, PlayerController.Instance.transform.position.z));
            this.gameObject.transform.LookAt(PlayerController.Instance.transform);
            this.gameObject.transform.rotation *= Quaternion.Euler(new Vector3(0, 180f, 0));
            this.gameObject.GetComponent<CapsuleCollider>().radius = 20;
            this.gameObject.GetComponent<CapsuleCollider>().height = 120;
        }
    }

    private void MoveTowardsPlayer(bool kill = false)
    {
        this.kill = kill;
        if (this.transform.position.z >= PlayerController.Instance.UnityFPSController.transform.position.z)
        {
            this.transform.position += new Vector3(0, 0, -1 * Time.deltaTime * crawlKillSpeed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(GameManager.Instance.Reset());
        }
    }

    public void SetCurrentStatus(EnemyStatus status)
    {
        currentEnemyStatus = status;
    }
}
