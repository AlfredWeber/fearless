using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    private GameObject triggerAI;
    private int[] coordsTriggers = {-33,-21,-11,-2};
    MeshRenderer m;
    int i = 0;

    //DON'T HAVE THE GAME OBJECT MOVE RIGHT AWAY, WAIT 10 SECONDS
    private bool isWait = true;
    private int DIST = 87 / 5;

    void Start()
    {       
        triggerAI = GameObject.FindWithTag("TriggerAI");
        m = GetComponent<MeshRenderer>();
        m.enabled = false;
        StartCoroutine(StartDelay());
    }
 
    private void Update()
    {
         //AFTER 10 SECONDS THE GAME OBJECT STARTS MOVING
         if (!isWait && triggerAI.GetComponent<TriggerWallMid>().triggered)
         {
            m.enabled = true;
            Move();
         }
    }
 
     private void Move()
     {
        // Vector3 newPos = new Vector3(coordsTriggers[i], transform.position.y, transform.position.z);
        Vector3 newPos = new Vector3(transform.position.x + DIST, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, newPos, moveSpeed * Time.deltaTime); // smooth
        // transform.position = newPos; // teleport
 
        if (transform.position == newPos)
        {
            if(i != coordsTriggers.Length-1) {
                i++;
            }
            StartCoroutine(StartDelay()); // restarts the coroutine
        }
 
     }
 
     //after 10 seconds, the object moves
     IEnumerator StartDelay()
     {
        
        
         isWait = true;//object now waits to move
         yield return new WaitForSeconds(5);
         isWait = false; //object is no longer waiting to move
     }
}
