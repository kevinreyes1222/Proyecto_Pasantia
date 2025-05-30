using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMove : MonoBehaviour
{
    public List<Transform> waypoints;
    NavMeshAgent agent;
    public int currentWaypointIndex = 0;
    public float rotationSpeed = 2f;
    public float angleToStartSlowing = 20f;
    public float maxSpeed = 8f;
    public float minSpeedInCurve = 3f;
    public float deceleration = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToWaypoint = Vector3.Distance(waypoints[currentWaypointIndex].position, transform.position);
        if(distanceToWaypoint <= 3)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
        }

        int nextIndex = (currentWaypointIndex + 1) % waypoints.Count;
        Vector3 currentDir = (waypoints[currentWaypointIndex].position - transform.position).normalized;
        Vector3 nextDir = (waypoints[nextIndex].position - waypoints[currentWaypointIndex].position).normalized;

        float angle = Vector3.Angle(currentDir, nextDir);

        float targetSpeed = maxSpeed;

        if (angle >= angleToStartSlowing)
        {
            float t = Mathf.InverseLerp(angleToStartSlowing, 90f, angle);
            targetSpeed = Mathf.Lerp(maxSpeed, minSpeedInCurve, t);
        }

        agent.speed = Mathf.Lerp(agent.speed, targetSpeed, Time.deltaTime * deceleration);
        agent.SetDestination(waypoints[currentWaypointIndex].position);

        Vector3 direction = agent.desiredVelocity;
        if (direction.sqrMagnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
