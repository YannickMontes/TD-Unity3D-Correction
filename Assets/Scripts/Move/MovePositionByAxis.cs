using UnityEngine;

public class MovePositionByAxis : MonoBehaviour
{
    public float speed = 10.0f;
    public bool rawAxis = false;

    private void FixedUpdate()
    {
        Vector3 movement = GetMovementFromAxisInputs();
        transform.position += movement * Time.fixedDeltaTime * speed;
    }

    private Vector3 GetMovementFromAxisInputs()
    {
        float horizontalAxis = rawAxis ? Input.GetAxisRaw("Horizontal") : Input.GetAxis("Horizontal");
        float verticalAxis = rawAxis ? Input.GetAxisRaw("Vertical") : Input.GetAxis("Vertical");

        return new Vector3(horizontalAxis, 0.0f, verticalAxis);
    }
}