using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    //R�f�rence au bouton appuy�
    [SerializeField] private InputActionReference jumpButton;
    //Valeur de la hauteur du saut
    [SerializeField] private float jumpheight = 2.0f;
    //R�ference a la gravit� du character controller du Rig 
    [SerializeField] private float gravityValue = -9.81f;
    
    //On r�cup�re le charachter controller
    private CharacterController _characterController;
    //On r�cup�re la velocity du joueur
    private Vector3 _playerVelocity;

    //R�cup�rer la r�f�rence du character controller dans la fonction Awake
    private void Awake() => _characterController = GetComponent<CharacterController>();

    //D�clanchement du jump a l'appui du bouton 
    private void OnEnable() => jumpButton.action.performed += Jumping;

    private void OnDisable() => jumpButton.action.performed -= Jumping;

    private void Jumping(InputAction.CallbackContext obj)
    {
        if (!_characterController.isGrounded) return;
        _playerVelocity.y += Mathf.Sqrt(jumpheight * -3.0f * gravityValue);
    }

    private void Update()
    {
        if (_characterController.isGrounded && _playerVelocity.y < 0)
        {
            _playerVelocity.y = 0f;
        }

        _playerVelocity.y += gravityValue * Time.deltaTime;
        _characterController.Move(_playerVelocity * Time.deltaTime);
    }
}
