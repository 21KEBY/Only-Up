using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueN1 : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject dialogueN1Panel;
    public TextMeshProUGUI dialogueN1Text;
    public Image characterImage;
    public Button startButton;
    public Image fadePanel; // Image noire pour la transition

    [Header("DialogueN1 Settings")]
    public string[] dialogueN1Lines = {
        "Salut, j'ai réussi à me connecter à ta combinaison.",
        "Hors du vaisseau c'est comme ça que tu me verra, sympa non?",
        "Alors, nous nous sommes crashé trop loin de la terre.",
        "Le portail tout là haut ne nous permettra pa directement d'aller sur terre.",
        "Nous allons donc aller de planète en planète pour arriver jusqu'à la terre.",
        "Vu que j'ai perdu ma connexion à la terre, je ne sais pas combien de temps nous mettrons.",
        "Mais ça peut être une aventure géniale.Lets go!!"
    };

    public Sprite[] characterSprites;
    private int currentLineIndex = 0;
    private float textSpeed = 0.05f;
    private bool isTyping = false;
    private Coroutine typingCoroutine;

    void Start()
    {
        dialogueN1Panel.SetActive(true);
        startButton.onClick.AddListener(ShowNextLine);
        typingCoroutine = StartCoroutine(TypeText(dialogueN1Lines[currentLineIndex]));

        // Assurer que le panneau noir est visible et transparent au départ
        fadePanel.gameObject.SetActive(true);
        fadePanel.color = new Color(0, 0, 0, 0); // Alpha = 0 (complètement transparent)
    }

    void ShowNextLine()
    {
        if (isTyping)
        {
            StopCoroutine(typingCoroutine);
            dialogueN1Text.text = dialogueN1Lines[currentLineIndex];
            isTyping = false;
        }
        else
        {
            currentLineIndex++;

            if (currentLineIndex < dialogueN1Lines.Length)
            {
                typingCoroutine = StartCoroutine(TypeText(dialogueN1Lines[currentLineIndex]));

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
        dialogueN1Text.text = "";

        foreach (char letter in line.ToCharArray())
        {
            dialogueN1Text.text += letter;
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
