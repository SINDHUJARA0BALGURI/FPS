using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float enemyMoveSpeed;
    public Rigidbody rb;
    //public Transfform target;
    bool chasing;
    public float distanceToChase,distanceToLoose,distanceToStop;
    public NavMeshAgent agent;
    Vector3 targetPoint, startPoint;
    public float keepChasingTime, chaseCounter;
    public GameObject enemyBulletPrefab;
    public Transform enemyFirePoint;
    public float fireRate,fireCount,fireWaitCounter,waitBetweenShoots,ShootTimeCounter;
    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.position;
        ShootTimeCounter = 1f;
        fireWaitCounter = waitBetweenShoots;
    }

    // Update is called once per frame
    void Update()
    {
        targetPoint = PlayerController.instance.transform.position;
        if (!chasing)
        {
            if (Vector3.Distance(transform.position, targetPoint) < distanceToChase)
            {
                chasing = true;
                // fireCount = 1.0f;
                ShootTimeCounter = 1f;
                fireWaitCounter = waitBetweenShoots;
            }
            if (chaseCounter > 0)
            {
                chaseCounter -= Time.deltaTime;
            }
            
            if (chaseCounter <= 0)
            {
                agent.destination = startPoint;
            }
        }
        else
        {

            // transform.LookAt(targetPoint);
            //transform.LookAt(PlayerController.instance.transform.position);
            //rb.velocity = transform.forward * enemyMoveSpeed;
            if (Vector3.Distance(transform.position, targetPoint) > distanceToStop)
            {
                agent.destination = targetPoint;
            }
            else
            {
                agent.destination = transform.position;
            }
           
            

            if (Vector3.Distance(transform.position, targetPoint) > distanceToLoose)
            {
                chasing= false;
                agent.destination = startPoint;
                chaseCounter = keepChasingTime;
            }
            if (fireWaitCounter > 0)
            {
                fireWaitCounter = -Time.deltaTime;
                if (fireWaitCounter <= 0)
                {
                    ShootTimeCounter = 1f;
                }
            }
            else
            {
                ShootTimeCounter -= Time.deltaTime;
                if (ShootTimeCounter > 0)
                {

                    fireCount -= Time.deltaTime;
                    if (fireCount <= 0)
                    {
                        fireCount = fireRate;
                        enemyFirePoint.LookAt(PlayerController.instance.transform.position+new Vector3(0f,1.5f,0f));

                        //check the angle of player
                        Vector3 targetDirection = PlayerController.instance.transform.position - transform.position;
                        float angle = Vector3.SignedAngle(targetDirection, transform.forward, Vector3.up);  //gives agle between two vectors
                        
                        if(Mathf.Abs(angle) < 40f)
                        {
                            Instantiate(enemyBulletPrefab, enemyFirePoint.position, enemyFirePoint.rotation);
                        }
                        else
                        {
                            fireWaitCounter = waitBetweenShoots;
                        }
                    }
                    agent.destination = transform.position;
                }
                else if (ShootTimeCounter <= 0)
                {
                    fireWaitCounter = waitBetweenShoots;
                }
            }
    
        }
    }
}
