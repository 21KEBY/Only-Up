using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class XRClimbing : MonoBehaviour
{
    public Transform playerRoot;                  // Le joueur � d�placer
    public InputActionProperty climbAction;       // Action d'entr�e pour l'escalade
    public LayerMask climbableLayer;              // Surfaces escaladables
    private Rigidbody playerRigidbody;            // Rigidbody du joueur
    private Vector3 previousHandPosition;         // Position pr�c�dente de la main
    private bool isClimbing = false;              // Statut de l'escalade

    void Start()
    {
        playerRigidbody = playerRoot.GetComponent<Rigidbody>();
    }

    void Update()
    {
        // V�rifie si le joueur est en train d'escalader
        if (isClimbing)
        {
            Vector3 handDelta = transform.position - previousHandPosition;
            playerRoot.position -= handDelta;     // D�place le joueur en fonction du mouvement de la main
            previousHandPosition = transform.position;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (((1 << other.gameObject.layer) & climbableLayer) != 0)
        {
            // D�tection de la saisie via l'Input Action "Climb"
            if (climbAction.action.ReadValue<float>() > 0.1f)
            {
                if (!isClimbing)
                {
                    StartClimbing();
                }
            }
            else if (isClimbing)
            {
                StopClimbing();
            }
        }
    }

    public void StartClimbing()
    {
        isClimbing = true;
        previousHandPosition = transform.position;

        // D�sactiver la gravit� pour un contr�le fluide
        if (playerRigidbody != null)
        {
            playerRigidbody.useGravity = false;
            playerRigidbody.velocity = Vector3.zero;
        }
    }

    public void StopClimbing()
    {
        isClimbing = false;

        // R�activer la gravit� apr�s l'escalade
        if (playerRigidbody != null)
        {
            playerRigidbody.useGravity = true;
        }
    }
}



