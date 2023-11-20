using UnityEngine;

public class MoveByVelocity : MonoBehaviour
{
    public ReadMovementInput readMovementInput = null;
    public Rigidbody moveRigidbody = null;
    public float speed = 10.0f;
    public bool lookAtInputsDirection = false;
    public bool useInputManager = false;

    private void FixedUpdate()
    {
        Vector2 movementInput = useInputManager
            ? InputManager.Instance.CurrentInputMovement
            : readMovementInput.CurrentMovementInput;

        moveRigidbody.velocity = new Vector3(movementInput.x * speed
            , moveRigidbody.velocity.y
            , movementInput.y * speed);

        if(lookAtInputsDirection)
        {
            Vector3 inputDirection = new Vector3(readMovementInput.CurrentMovementInput.x, 0.0f, readMovementInput.CurrentMovementInput.y);
            transform.LookAt(transform.position + inputDirection, Vector3.up);
        }
    }
}
