using UnityEngine;
using TMPro;

public class VRChrono : MonoBehaviour
{
    public TextMeshProUGUI chronoText; // Référence au texte UI
    private float timeElapsed = 0f;
    private bool isRunning = true; // Démarre immédiatement

    void Update()
    {
        if (isRunning)
        {
            timeElapsed += Time.deltaTime;
            UpdateChronoDisplay();
        }
    }

    private void UpdateChronoDisplay()
    {
        int minutes = Mathf.FloorToInt(timeElapsed / 60);
        int seconds = Mathf.FloorToInt(timeElapsed % 60);
        int milliseconds = Mathf.FloorToInt((timeElapsed * 1000) % 1000);

        // ✅ Format propre pour affichage correct
        chronoText.text = $"{minutes:00}:{seconds:00}:{milliseconds:000}";
    }

    public void ResetChrono()
    {
        timeElapsed = 0f;
        UpdateChronoDisplay();
    }
}
