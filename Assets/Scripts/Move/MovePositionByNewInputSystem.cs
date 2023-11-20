using UnityEngine;
using UnityEngine.InputSystem;

public class MovePositionByNewInputSystem : MonoBehaviour
{
    public InputActionReference moveInput = null;
    public float speed = 10.0f;
    public float smoothSpeed = 0.0f;

    private Vector3 currentInputVector = Vector3.zero;
    private Vector3 smoothInputVelocity = Vector3.zero;

    private void FixedUpdate()
    {
        Vector3 movement = GetMovementInput();
        transform.position += movement * Time.fixedDeltaTime * speed;
    }

    private Vector3 GetMovementInput()
    {
        Vector3 input = moveInput.action.ReadValue<Vector2>();
        Vector3 movementInput = new Vector3(input.x, 0.0f, input.y);

        currentInputVector = Vector3.SmoothDamp(currentInputVector, movementInput, ref smoothInputVelocity, smoothSpeed);

        return currentInputVector;
    }
}
