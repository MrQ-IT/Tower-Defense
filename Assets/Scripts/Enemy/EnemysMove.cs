using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// dung class nay de di chuyen ke dich

public class EnemysMove : MonoBehaviour
{
    private int enemySpeed;
    private WaypointManager waypointManager;
    private int indexWaypoint;
    private Vector3 direction;
    private LivesManager livesManager;

    private void Start()
    {
        Initialize();
    }

    void Update()
    {   
        EnemyMoves();
    }

    private void Initialize()
    {
        livesManager = UIManager.main.GetComponentInChildren<LivesManager>();
        waypointManager = GameObject.Find("WayPoints").GetComponent<WaypointManager>();
        enemySpeed = GetComponent<Bee>().speed;
        indexWaypoint = 0;
    }

    private void EnemyMoves()
    {
        if (indexWaypoint < waypointManager.wayPoints.Length)
        {
            Transform targetWaypoint = waypointManager.wayPoints[indexWaypoint];
            direction = targetWaypoint.position - transform.position;
            transform.Translate(direction.normalized * enemySpeed * Time.deltaTime);
            GetComponent<Bee>().ChangeMovementAnimation(direction);
            if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.01f)
            {
                indexWaypoint++;
            }
        }
        else
        {   
            livesManager.DecreaseLives();
            GetComponent<Bee>().RemoveOnPathEnd();
        }
    }
    
}
