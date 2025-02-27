using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public Image fadePanel; // Associe l'image noire ici
    public float fadeDuration = 1f; // Durée du fondu

    private void Start()
    {
        fadePanel.gameObject.SetActive(true);
        StartCoroutine(FadeIn()); // Effet fondu d'entrée si nécessaire
    }

    public void StartSceneTransition(string sceneName)
    {
        StartCoroutine(FadeOut(sceneName));
    }

    IEnumerator FadeOut(string sceneName)
    {
        float t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            fadePanel.color = new Color(0, 0, 0, t / fadeDuration);
            yield return null;
        }
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator FadeIn()
    {
        float t = fadeDuration;
        while (t > 0)
        {
            t -= Time.deltaTime;
            fadePanel.color = new Color(0, 0, 0, t / fadeDuration);
            yield return null;
        }
        fadePanel.gameObject.SetActive(false);
    }
}
