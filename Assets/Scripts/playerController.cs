using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
    private CharacterController controller;
    private Vector2 moveInput;
    private Vector2 lookInput;
    private Vector3 currentVelocity;

    public float maxSpeed = 10f;
    public float acceleration = 0.5f;
    public float deceleration = 5f;
    public float rotationSpeed = 5f;

    private void Start() {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate() {
        Move();
        Rotate();
    }

    private void Move() {
        Vector3 desiredMoveDirection = transform.forward * moveInput.y + transform.right * moveInput.x;
        desiredMoveDirection.Normalize();
        Vector3 targetVelocity = desiredMoveDirection * maxSpeed;

        currentVelocity = Vector3.Lerp(currentVelocity, targetVelocity, Time.deltaTime * acceleration);

        if (moveInput == Vector2.zero) {
            currentVelocity = Vector3.Lerp(currentVelocity, Vector3.zero, Time.deltaTime * deceleration);
        }

        controller.Move(currentVelocity * Time.deltaTime);
    }

    private void Rotate() {
        transform.Rotate(Vector3.up, lookInput.x * rotationSpeed * Time.deltaTime);
    }

    public void OnMove(InputValue value) {
        moveInput = value.Get<Vector2>();
    }

    private void OnLook(InputValue value) {
        lookInput = value.Get<Vector2>();
    }
}
