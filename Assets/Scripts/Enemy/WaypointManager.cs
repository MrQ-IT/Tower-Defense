using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// su dung class nay de luu cac vi tri a ke dich can di chuyen den


public class WaypointManager : MonoBehaviour
{
    public Transform[] wayPoints;

    private void OnDrawGizmos()
    {
        for (int i = 0; i < wayPoints.Length-1; i++)
        {
            Gizmos.DrawLine(wayPoints[i].position, wayPoints[i + 1].position);
        }
    }
}
