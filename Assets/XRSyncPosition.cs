using UnityEngine;

public class XRSyncPosition : MonoBehaviour
{
    public Transform headTransform; // La caméra (VR Headset)
    public Transform characterTransform; // CharacterController Parent

    void LateUpdate()
    {
        // Récupérer la position du joueur mais garder la hauteur du CharacterController
        Vector3 newPosition = headTransform.position;
        newPosition.y = characterTransform.position.y; // Garde la même hauteur

        // Appliquer la position
        characterTransform.position = newPosition;
    }
}
