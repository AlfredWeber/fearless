using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController Instance { get; private set; }
    private Animator animator;
    public enum EnemyStatus { IDLE, CRAWL, CRAWL_KILL };
    private EnemyStatus currentEnemyStatus = EnemyStatus.IDLE;
    private float crawlKillSpeed = 15f;
    private bool kill;

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
    }

    private void Update()
    {
        if (currentEnemyStatus == EnemyStatus.CRAWL_KILL)
        {
            if (!animator.GetBool("isCrawling")) animator.SetBool("isCrawling", true);
            MoveTowardsPlayer(true);
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
