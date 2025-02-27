using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Dash : MonoBehaviour
{
    public Slider slider;
    [SerializeField] private InputActionReference DashButton;
    [SerializeField] private float dashForce = 5.0f;
    [SerializeField] private float dashDuration = 0.2f;
    [SerializeField] private float dashCooldown = 1.0f;
    [SerializeField] private AudioSource dashSound; // Son du dash

    private CharacterController _characterController;
    private Vector3 _dashDirection;
    private bool _isDashing = false;
    private float _dashTimer = 0f;
    private float _cooldownTimer = 0f;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();

        if (slider == null)
        {
            slider = FindObjectOfType<Slider>();
        }

        if (slider != null)
        {
            slider.maxValue = 1;
            slider.value = 1;
        }
    }

    private void OnEnable()
    {
        DashButton.action.performed += Dashing;
    }

    private void OnDisable()
    {
        DashButton.action.performed -= Dashing;
    }

    private void Update()
    {
        if (_isDashing)
        {
            _dashTimer -= Time.deltaTime;
            if (_dashTimer <= 0)
            {
                _isDashing = false;
                _cooldownTimer = dashCooldown;
            }
            else
            {
                _characterController.Move(_dashDirection * dashForce * Time.deltaTime);
            }
        }
        else if (_cooldownTimer > 0)
        {
            _cooldownTimer -= Time.deltaTime;
        }

        UpdateDashBar();
    }

    private void Dashing(InputAction.CallbackContext obj)
    {
        if (!_isDashing && _cooldownTimer <= 0)
        {
            _isDashing = true;
            _dashTimer = dashDuration;
            _dashDirection = transform.forward;

            if (dashSound != null)
            {
                dashSound.Play(); // Joue le son du dash
            }
        }
    }

    private void UpdateDashBar()
    {
        if (slider != null)
        {
            float cooldownProgress = 1 - (_cooldownTimer / dashCooldown);
            slider.value = cooldownProgress;
        }
    }
}
