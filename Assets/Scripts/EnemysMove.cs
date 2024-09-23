using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// dung class nay de di chuyen ke dich

public class EnemysMove : MonoBehaviour
{
    private int enemySpeed = 2;
    private WaypointManager waypointManager;
    private int indexWaypoint = 0;
    private Animator animator;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {   
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {   
        EnemyMoves();
    }

    private void Initialize()
    {
        animator = GetComponent<Animator>();
        WaypointManager waypointsObject = GameObject.Find("WayPoints").GetComponent<WaypointManager>();
        if (waypointsObject != null)
        {
            waypointManager = waypointsObject;
        }
        else
        {
            Debug.Log("Waypoint Manager is null !");
        }
    }
    private void ChangeMovementAnimation()
    {
        animator.SetFloat("X", direction.normalized.x);
        animator.SetFloat("Y", direction.normalized.y);
    }
    private void EnemyMoves()
    {
        if (indexWaypoint < waypointManager.wayPoints.Length)
        {
            Transform targetWaypoint = waypointManager.wayPoints[indexWaypoint];
            direction = targetWaypoint.position - transform.position;
            transform.Translate(direction.normalized * enemySpeed * Time.deltaTime);
            ChangeMovementAnimation();
            if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.01f)
            {
                indexWaypoint++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
}
