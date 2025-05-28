using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMove : MonoBehaviour
{
    public List<Transform> waypoints;
    NavMeshAgent agent;
    public int currentWaypointIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToWaypoint = Vector3.Distance(waypoints[currentWaypointIndex].position, transform.position);
        if(distanceToWaypoint <= 3)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
        }
        agent.SetDestination(waypoints[currentWaypointIndex].position);
    }
}
