using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject dialoguePanel; // Panneau du dialogue
    public TextMeshProUGUI dialogueText; // Texte du dialogue
    public Image characterImage; // Image du personnage
    public Button startButton; // Bouton pour continuer le dialogue

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

    public Sprite[] characterSprites; // Images des personnages
    private int currentLineIndex = 0;
    private float textSpeed = 0.05f; // Vitesse du défilement du texte
    private bool isTyping = false; // Pour vérifier si le texte est en train de s'afficher
    private Coroutine typingCoroutine; // Stocke la coroutine en cours

    void Start()
    {
        dialoguePanel.SetActive(true); // Active le dialogue dès le lancement
        startButton.onClick.AddListener(ShowNextLine); // Ajoute un listener au bouton
        typingCoroutine = StartCoroutine(TypeText(dialogueLines[currentLineIndex])); // Lance le premier dialogue
    }

    void ShowNextLine()
    {
        if (isTyping) // Si le texte est en train de s'afficher
        {
            StopCoroutine(typingCoroutine); // Arrête l'affichage progressif
            dialogueText.text = dialogueLines[currentLineIndex]; // Affiche tout d'un coup
            isTyping = false;
        }
        else // Si tout le texte est déjà affiché
        {
            currentLineIndex++;

            if (currentLineIndex < dialogueLines.Length)
            {
                typingCoroutine = StartCoroutine(TypeText(dialogueLines[currentLineIndex]));

                // Changer l’image si nécessaire
                if (characterSprites.Length > currentLineIndex)
                {
                    characterImage.sprite = characterSprites[currentLineIndex];
                }
            }
            else
            {
                LoadNextScene(); // Charge la scène 2 à la fin du dialogue
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

    void LoadNextScene()
    {
        SceneManager.LoadScene(1); // Charge la scène "MenuScene"
    }
}
