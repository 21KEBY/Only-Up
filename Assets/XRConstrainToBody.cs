using UnityEngine;

public class XRConstrainToBody : MonoBehaviour
{
    public CharacterController characterController;
    public Transform cameraTransform;
    public Transform leftHand;
    public Transform rightHand;

    public float handOffset = 0.2f; // Distance supplémentaire autorisée pour les mains

    void LateUpdate()
    {
        // La caméra doit être à l'intérieur du CharacterController
        ConstrainToCharacterBounds(cameraTransform, 0f);

        // Les mains peuvent aller légèrement au-delà du CharacterController
        ConstrainToCharacterBounds(leftHand, handOffset);
        ConstrainToCharacterBounds(rightHand, handOffset);
    }

    void ConstrainToCharacterBounds(Transform target, float extraRadius)
    {
        Vector3 position = target.position;

        // Centre du CharacterController
        Vector3 characterCenter = characterController.transform.position + characterController.center;
        float radius = characterController.radius + extraRadius; // Taille du corps + marge

        // Calcul de la distance entre la cible et le centre du CharacterController
        Vector3 offset = position - characterCenter;
        if (offset.magnitude > radius) // Si la cible dépasse la limite
        {
            position = characterCenter + offset.normalized * radius; // Ramène la cible dans la limite
        }

        target.position = position; // Applique la correction
    }
}
