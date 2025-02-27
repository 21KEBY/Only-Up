using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.InputSystem;

public class DisplayCanvas : MonoBehaviour
{
    public GameObject _canvasUI;
    [SerializeField] private InputActionReference _activationbutton;

    private void Awake() => _activationbutton = GetComponent<InputActionReference>();
    private void OnEnable() => _activationbutton.action.performed += ToggleCanvas;

    //Le canvas est caché de base et si on clique on va l'afficher
    private void Start()
    {
        //On désactive le Canvas
        _canvasUI.SetActive(false);
    }

    public void ToggleCanvas(InputAction.CallbackContext obj)
    {
        
        _canvasUI.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) // Quand on appuie sur "M"
        {
            _canvasUI.SetActive(!_canvasUI.activeSelf);
        }
    }


}
