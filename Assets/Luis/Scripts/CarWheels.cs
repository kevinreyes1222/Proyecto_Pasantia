using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarWheels : MonoBehaviour
{
    public List<Transform> wheels;
    public float turnThreshold = 0.5f;
    public float maxSteeringAngle = 20f;
    public float wheelSteerSpeed = 5f;
    public float maxSpeed = 10f;
    public float minSpeedInCurve = 3f;
    public float angleToStartSlowing = 10f;
    NavMeshAgent agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Transform wheel in wheels)
        {
            wheel.Rotate(agent.speed, 0.0f, 0.0f);
        }

        Vector3 velocity = agent.desiredVelocity.normalized;
        if (velocity.magnitude > 0.1f)
        {
            float angle = Vector3.SignedAngle(transform.forward, velocity, Vector3.up);

            foreach (Transform wheel in wheels)
            {
                Transform parent = wheel.parent;
                Vector3 euler = parent.localEulerAngles;

                float currentY = euler.y;
                if (currentY > 180f) 
                    currentY -= 360f;

                if (Mathf.Abs(angle) > turnThreshold)
                {
                    float targetAngle = Mathf.Clamp(angle + 10f, -maxSteeringAngle, maxSteeringAngle);
                    euler.y = targetAngle;
                    float newY = Mathf.Lerp(currentY, targetAngle, Time.deltaTime * wheelSteerSpeed);
                    parent.localEulerAngles = new Vector3(euler.x, newY, euler.z);
                }
                else
                {
                    euler.y = Mathf.LerpAngle(currentY, 0f, Time.deltaTime * 2f);
                    parent.localEulerAngles = new Vector3(euler.x, euler.y, euler.z);
                }

            }

            float t = Mathf.InverseLerp(angleToStartSlowing, 45f, Mathf.Abs(angle));
            float targetSpeed = Mathf.Lerp(maxSpeed, minSpeedInCurve, t);
            agent.speed = Mathf.Lerp(agent.speed, targetSpeed, Time.deltaTime * 2f);
        }
    }
}
