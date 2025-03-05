using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public Transform player; // R�f�rence au joueur
    public TextMeshProUGUI scoreText; // R�f�rence � l'UI du score
    private float startY; // Position Y de d�part du joueur

    void Start()
    {
        if (player != null)
        {
            startY = player.position.y; // Enregistre la position initiale
        }
    }

    void Update()
    {
        if (player != null && scoreText != null)
        {
            float height = Mathf.Max(0, player.position.y - startY); // Calcul de la hauteur
            scoreText.text = "Score : " + height.ToString("F2") + "m"; // Affichage avec 2 d�cimales
        }
    }
}
