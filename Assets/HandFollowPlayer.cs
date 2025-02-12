using UnityEngine;

public class HandFollowPlayer : MonoBehaviour
{
    public Transform player;  // Référence au joueur
    private Vector3 offset;   // Distance initiale entre la main et le joueur

    void Start()
    {
        offset = transform.position - player.position;
    }

    void Update()
    {
        transform.position = player.position + offset;
    }
}
