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

    private void Awake() {
        controller = GetComponent<CharacterController>();
    }

    private void FixedUpdate() {
        Move();

        if (Input.GetKey(KeyCode.Space) && controller.isGrounded) {
        }
    }

    private void Move() {
        Vector3 desiredMoveDirection = new Vector3(moveInput.x, 0f, moveInput.y);
        Vector3 targetVelocity = desiredMoveDirection * maxSpeed;

        currentVelocity = Vector3.Lerp(currentVelocity, targetVelocity, Time.deltaTime * acceleration);

        if (moveInput == Vector2.zero) {
            currentVelocity = Vector3.Lerp(currentVelocity, Vector3.zero, Time.deltaTime * deceleration);
        }

        currentVelocity = transform.TransformDirection(currentVelocity);

        controller.Move(currentVelocity * Time.deltaTime);
    }

    public void OnMove(InputValue value) {
        moveInput = value.Get<Vector2>();
    }

    private void OnLook(InputValue value) {
        lookInput = value.Get<Vector2>();
        Debug.Log(lookInput);
    }
}
