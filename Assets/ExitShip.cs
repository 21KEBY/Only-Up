using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitShip : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Vérifie si c'est bien le joueur
        {
            SceneManager.LoadScene("Niveau1"); // Remplace par le nom de la scène extérieure
        }
    }
}
