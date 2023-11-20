using UnityEngine;
using UnityEngine.InputSystem;

public class ReadMovementInput : MonoBehaviour
{
    public InputActionReference moveInput = null;
    public float smoothSpeed = 0.0f;

    private Vector2 smoothInputVelocity = Vector2.zero;

    public Vector2 CurrentMovementInput { get; private set; }

    private void Update()
    {
        Vector2 input = moveInput.action.ReadValue<Vector2>();

        CurrentMovementInput = Vector2.SmoothDamp(CurrentMovementInput, input, ref smoothInputVelocity, smoothSpeed);
    }
}
