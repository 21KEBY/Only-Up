using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public Image characterImage;
    public Button startButton;
    public Image fadePanel; // Image noire pour la transition

    [Header("Dialogue Settings")]
    public string[] dialogueLines = {
        "Nous avons fait un crash avec notre vaisseau spatial.",
        "Nous devons trouver un moyen de réparer le vaisseau pour rentrer chez nous.",
        "Il faut trouver des pièces de rechange pour réparer le vaisseau.",
        "Allons explorer cette galaxie pour trouver des pièces de rechange.",
        "Je vais te guider pour sortir du vaisseau.",
        "À l'extérieur se trouve un portail pour nous téléporter sur une autre planète.",
        "Je suis connecté à ta combinaison pour te guider hors du vaisseau."
    };

    public Sprite[] characterSprites;
    private int currentLineIndex = 0;
    private float textSpeed = 0.05f;
    private bool isTyping = false;
    private Coroutine typingCoroutine;

    void Start()
    {
        dialoguePanel.SetActive(true);
        startButton.onClick.AddListener(ShowNextLine);
        typingCoroutine = StartCoroutine(TypeText(dialogueLines[currentLineIndex]));

        // Assurer que le panneau noir est visible et transparent au départ
        fadePanel.gameObject.SetActive(true);
        fadePanel.color = new Color(0, 0, 0, 0); // Alpha = 0 (complètement transparent)
    }

    void ShowNextLine()
    {
        if (isTyping)
        {
            StopCoroutine(typingCoroutine);
            dialogueText.text = dialogueLines[currentLineIndex];
            isTyping = false;
        }
        else
        {
            currentLineIndex++;

            if (currentLineIndex < dialogueLines.Length)
            {
                typingCoroutine = StartCoroutine(TypeText(dialogueLines[currentLineIndex]));

                if (characterSprites.Length > currentLineIndex)
                {
                    characterImage.sprite = characterSprites[currentLineIndex];
                }
            }
            else
            {
                StartCoroutine(FadeToBlackAndLoadScene(4)); // Transition vers la scène 4
            }
        }
    }

    IEnumerator TypeText(string line)
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char letter in line.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }

        isTyping = false;
    }

    IEnumerator FadeToBlackAndLoadScene(int sceneIndex)
    {
        float fadeDuration = 1f;
        float t = 0;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            fadePanel.color = new Color(0, 0, 0, t / fadeDuration); // Fait passer à noir progressivement
            yield return null;
        }

        SceneManager.LoadScene(sceneIndex); // Charge la scène 4
    }
}
