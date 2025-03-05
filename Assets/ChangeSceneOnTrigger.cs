using UnityEngine;
using UnityEngine.SceneManagement; // Nécessaire pour changer de scène

public class ChangeSceneOnTrigger : MonoBehaviour
{
    // Remplacez par le nom de la scène à charger
    public string sceneName = "NomDeLaScene";

    // Détecte la collision avec un autre objet
    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'objet qui entre est le joueur (tag "Player")
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
