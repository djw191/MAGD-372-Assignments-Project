using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 11f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private LayerMask ground;
    [SerializeField] private Transform groundedCheck;
    [SerializeField] private float jumpHeight = 3f;
    private bool jump;
    private bool isGrounded;
    private Vector3 verticalVelocity = Vector3.zero;
    private Vector2 horizontalInput;

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundedCheck.position, 0.1f, ground);
        if (isGrounded)
            verticalVelocity.y = -2f;

        Vector3 horizontalVelocity =
            (transform.right * horizontalInput.x + transform.forward * horizontalInput.y) * speed;

        controller.Move(horizontalVelocity * Time.deltaTime);

        if (jump) {
            if (isGrounded) {
                verticalVelocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity);
            }
            jump = false;
        }

        verticalVelocity.y += gravity * Time.deltaTime;
        controller.Move(verticalVelocity * Time.deltaTime);
    }
    public void ReceiveInput(Vector2 _horizontalInput)
    {
        horizontalInput = _horizontalInput;
    }

    public void OnJumpPressed()
    {
        jump = true;
    }
}
