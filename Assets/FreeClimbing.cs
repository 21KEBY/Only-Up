using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class XRClimbing : MonoBehaviour
{
    public Transform playerRoot;                  // Le joueur à déplacer
    public InputActionProperty climbAction;       // Action d'entrée pour l'escalade
    public LayerMask climbableLayer;              // Surfaces escaladables
    private Rigidbody playerRigidbody;            // Rigidbody du joueur
    private Vector3 previousHandPosition;         // Position précédente de la main
    private bool isClimbing = false;              // Statut de l'escalade

    void Start()
    {
        playerRigidbody = playerRoot.GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Vérifie si le joueur est en train d'escalader
        if (isClimbing)
        {
            Vector3 handDelta = transform.position - previousHandPosition;
            playerRoot.position -= handDelta;     // Déplace le joueur en fonction du mouvement de la main
            previousHandPosition = transform.position;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (((1 << other.gameObject.layer) & climbableLayer) != 0)
        {
            // Détection de la saisie via l'Input Action "Climb"
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

        // Désactiver la gravité pour un contrôle fluide
        if (playerRigidbody != null)
        {
            playerRigidbody.useGravity = false;
            playerRigidbody.velocity = Vector3.zero;
        }
    }

    public void StopClimbing()
    {
        isClimbing = false;

        // Réactiver la gravité après l'escalade
        if (playerRigidbody != null)
        {
            playerRigidbody.useGravity = true;
        }
    }
}



