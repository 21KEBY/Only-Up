using UnityEngine;
using UnityEngine.InputSystem; // Nouveau système d'entrée
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class JumpController : MonoBehaviour
{
    public float jumpForce = 5f;
    public float gravity = -9.8f; // Gravité
    private bool isGrounded;

    private CharacterController characterController;
    public ClimbProvider climbProvider;
    // Action d'entrée pour le saut
    public InputActionReference jumpAction;

    private Vector3 velocity;

    void Start()
    {
        // Initialisation du CharacterController
        characterController = GetComponent<CharacterController>();

        // Activer l'action de saut
        if (jumpAction != null)
        {
            jumpAction.action.Enable();
            jumpAction.action.performed += ctx => Jump(); // Détecter l'appui sur le bouton de saut
        }
    }

    void Update()
    {
        print(climbProvider.climbAnchorInteractable);
        if (climbProvider != null && climbProvider.climbAnchorInteractable) return;
        // Vérifier si le joueur touche le sol
        isGrounded = characterController.isGrounded;

        // Appliquer la gravité
        if (!isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        //print(velocity.y);
        // Appliquer les mouvements et la gravité via le CharacterController
        characterController.Move(velocity * Time.deltaTime);
    }

    void Jump()
    {
        // Effectuer le saut uniquement si le joueur est au sol
        if (isGrounded)
        {
            velocity.y = jumpForce; // Applique la force de saut
        }
    }

    void OnDestroy()
    {
        if (jumpAction != null)
        {
            jumpAction.action.performed -= ctx => Jump(); // Nettoyer l'événement
        }
    }
}
