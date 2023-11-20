using UnityEngine;
using UnityEngine.InputSystem;

public class JumpBehaviour : MonoBehaviour
{
    public Rigidbody objectRigidbody = null;
    public float jumpForce = 200.0f;
    public bool oldInputSystem = false;
    public InputActionReference jumpInputRef = null;
    public GroundCheck groundCheck = null;

    private void OnEnable()
    {
        jumpInputRef.action.performed += OnJumpNewInputSystem;
    }

    private void OnDisable()
    {
        jumpInputRef.action.performed -= OnJumpNewInputSystem;
    }

    private void Update()
    {
        if(oldInputSystem && IsJumpingOldSystem())
        {
            Jump();
        }
    }

    private bool IsJumpingOldSystem()
    {
        return Input.GetKeyUp(KeyCode.Space);
    }

    private void OnJumpNewInputSystem(InputAction.CallbackContext context)
    {
        if (!oldInputSystem)
        {
            Jump();
        }
    }

    private void Jump()
    {
        if(groundCheck == null || groundCheck.IsGrounded)
            objectRigidbody.AddForce(Vector3.up * jumpForce);
    }
}
