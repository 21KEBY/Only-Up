using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ClimbingSystem : MonoBehaviour
{
    public XRController leftHand, rightHand;
    private CharacterController character;
    private bool isClimbing = false;
    private Transform climbingHand;

    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (isClimbing)
        {
            Vector3 handPosition = climbingHand.position;
            character.Move((handPosition - transform.position) * Time.deltaTime * 5f);
        }
    }

    public void StartClimbing(Transform hand)
    {
        isClimbing = true;
        climbingHand = hand;
    }

    public void StopClimbing()
    {
        isClimbing = false;
    }
}
