using UnityEngine;

public class MovePositionByKeys : MonoBehaviour
{
    public float speed = 10.0f;

    private void FixedUpdate()
    {
        Vector3 movement = GetMovementFromKeys();
        transform.position += movement * Time.fixedDeltaTime * speed;
    }

    private Vector3 GetMovementFromKeys()
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            movement.z = 1.0f;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movement.x = -1.0f;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            movement.z = -1.0f;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            movement.x = 1.0f;
        }
        return movement;
    }
}
