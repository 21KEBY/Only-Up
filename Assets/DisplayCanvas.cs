using UnityEngine;

public class ToggleCanvasWithKey : MonoBehaviour
{
    public GameObject canvasUI; // Assigne ton Canvas dans l'Inspector

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) // Quand on appuie sur "M"
        {
            canvasUI.SetActive(!canvasUI.activeSelf);
        }
    }
}