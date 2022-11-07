using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;

public class WaypointPath : MonoBehaviour
{
   public Transform GetWaypoint(int waypointIndex)
    {
        return transform.GetChild(waypointIndex);
    }

    public int GetNextWaypointIndex(int currentWaypointIndex)
    {
        int nextWaypointIndex = currentWaypointIndex + 1;

        if (nextWaypointIndex == transform.childCount)
        {
            nextWaypointIndex = 0;
        }

        return nextWaypointIndex;
    }

    private void OnDrawGizmos()
    {
        if (IsWaypointSelected())
        {
            DrawWaypointGizmos();
        }
    }

    public void DrawWaypointGizmos()
    {
        for (int waypointIndex = 0; waypointIndex < transform.childCount; waypointIndex++)
        {
            var waypoint = GetWaypoint(waypointIndex);

            Gizmos.color = Color.cyan;
            Gizmos.DrawSphere(waypoint.position, 0.2f);

            int nextWaypointIndex = GetNextWaypointIndex(waypointIndex);
            var nextWaypoint = GetWaypoint(nextWaypointIndex);

            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(waypoint.position, nextWaypoint.position);
        }
    }

    private bool IsWaypointSelected()
    {
        if (Selection.transforms.Contains(transform))
        {
            return true;
        }

        foreach (Transform child in transform)
        {
            if (Selection.transforms.Contains(child))
            {
                return true;
            }
        }

        return false;
    }
}
