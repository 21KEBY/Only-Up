using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public Transform teleportTarget; // Position de destination
    public GameObject player; // Référence au joueur

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Vérifie si c'est bien le joueur
        {
            player.transform.position = teleportTarget.position; // Téléporte le joueur
            player.transform.rotation = teleportTarget.rotation; // Garde l'orientation
        }
    }
}
