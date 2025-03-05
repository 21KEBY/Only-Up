using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanel : MonoBehaviour
{
    public GameObject textPanel;  // Le panneau de texte à activer/désactiver
    public float activationDistance = 2.0f;  // Distance pour afficher l'info

    private Transform player;

    void Start()
    {
        player = Camera.main.transform;  // Récupère la position de la caméra du joueur
        textPanel.SetActive(false);  // Masque le panneau au départ
    }

    void Update()
    {
        // Vérifie la distance entre le joueur et le panneau
        if (Vector3.Distance(player.position, transform.position) < activationDistance)
        {
            textPanel.SetActive(true);
        }
        else
        {
            textPanel.SetActive(false);
        }
    }
}

