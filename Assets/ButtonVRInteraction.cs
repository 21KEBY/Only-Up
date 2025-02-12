using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonVRInteraction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Color hoverColor = Color.red; // Couleur au survol
    public Color clickColor = Color.green; // Couleur après clic
    public Color normalColor = Color.white; // Couleur normale
    public string sceneToLoad = "MenuScene"; // Nom de la scène à charger

    private Image buttonImage;

    void Start()
    {
        buttonImage = GetComponent<Image>(); // Récupérer l'image du bouton
        buttonImage.color = normalColor; // Appliquer la couleur normale
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.color = hoverColor; // Change la couleur au survol
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.color = normalColor; // Remet la couleur normale
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        buttonImage.color = clickColor; // Change la couleur après clic
        Debug.Log("Bouton cliqué !");
        
        // Charger la nouvelle scène après une courte attente
        Invoke("ChangeScene", 0.5f);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
