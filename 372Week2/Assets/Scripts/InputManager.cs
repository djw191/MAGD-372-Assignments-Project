using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Movement movement;
    [SerializeField] private MouseLook mouseLook;
    private PlayerControls controls;
    private PlayerControls.GroundMovementActions GroundMovement;
    private Vector2 horizontalInput;
    private Vector2 mouseInput;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;

        controls = new PlayerControls();
        GroundMovement = controls.GroundMovement;
        GroundMovement.HorizontalMovement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();
        GroundMovement.Jump.performed += _ => movement.OnJumpPressed();
        GroundMovement.Use.performed += _ => movement.OnUse();
        GroundMovement.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        GroundMovement.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();
    }
    private void Update()
    {
        movement.ReceiveInput(horizontalInput);
        mouseLook.ReceiveInput(mouseInput);
    }
    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDestroy()
    {
        controls.Disable();
    }
}
