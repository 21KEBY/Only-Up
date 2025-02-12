using UnityEngine;

public class VRMovement : MonoBehaviour
{
    public Transform cameraTransform; // La caméra VR (Main Camera)
    public float speed = 2f;

    void Update()
    {
        // Récupérer la direction de la tête (sans l'inclinaison vers le haut/bas)
        Vector3 forward = new Vector3(cameraTransform.forward.x, 0, cameraTransform.forward.z).normalized;

        // Déplacer le joueur dans cette direction
        transform.position += forward * speed * Time.deltaTime;
    }
}
