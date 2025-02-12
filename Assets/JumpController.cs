using UnityEngine;
using UnityEngine.InputSystem; // Nouveau syst�me d'entr�e
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class JumpController : MonoBehaviour
{
    public float jumpForce = 5f;
    public float gravity = -9.8f; // Gravit�
    private bool isGrounded;

    private CharacterController characterController;
    public ClimbProvider climbProvider;
    // Action d'entr�e pour le saut
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
            jumpAction.action.performed += ctx => Jump(); // D�tecter l'appui sur le bouton de saut
        }
    }

    void Update()
    {
        print(climbProvider.climbAnchorInteractable);
        if (climbProvider != null && climbProvider.climbAnchorInteractable) return;
        // V�rifier si le joueur touche le sol
        isGrounded = characterController.isGrounded;

        // Appliquer la gravit�
        if (!isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        //print(velocity.y);
        // Appliquer les mouvements et la gravit� via le CharacterController
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
            jumpAction.action.performed -= ctx => Jump(); // Nettoyer l'�v�nement
        }
    }
}
