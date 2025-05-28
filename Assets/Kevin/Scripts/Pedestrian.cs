using UnityEngine;
using UnityEngine.AI;

public class Pedestrian : MonoBehaviour
{

    public NavMeshAgent agent; // Reference to the NavMeshAgent component
    public float speed;
    public Transform[] targets;
    public Transform target;
    public float distance;

    public Animation Anim;
    public string walkAnim;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = targets[Random.Range(0, targets.Length)]; // Randomly select a target from the array
        Anim.Play(walkAnim); // Start the walking animation
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, target.position); // Calculate the distance to the target

        if (distance < 2f) // If the pedestrian is close to the target
        {
            target = targets[Random.Range(0, targets.Length)]; // Select a new random target
        }

        agent.destination = target.position; 
        agent.speed = speed; // Set the speed of the NavMeshAgent    
    }
}
