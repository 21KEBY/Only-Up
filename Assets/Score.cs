using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public Transform player; // Référence au joueur
    public TextMeshProUGUI scoreText; // Référence à l'UI du score
    private float startY; // Position Y de départ du joueur

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
            scoreText.text = "Score : " + height.ToString("F2") + "m"; // Affichage avec 2 décimales
        }
    }
}
