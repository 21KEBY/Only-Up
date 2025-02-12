using UnityEngine;

public class HandClimb : MonoBehaviour
{
    private ClimbingSystem climbingSystem;

    void Start()
    {
        climbingSystem = FindObjectOfType<ClimbingSystem>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Climbable"))
        {
            climbingSystem.StartClimbing(transform);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Climbable"))
        {
            climbingSystem.StopClimbing();
        }
    }
}
