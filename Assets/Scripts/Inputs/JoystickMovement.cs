using UnityEngine;

public class JoystickMovement : MonoBehaviour
{
    public Joystick jostick = null;

    private void Update()
    {
        if(InputManager.Instance != null && !InputManager.Instance.readMovementFromKeyboard)
        {
            InputManager.Instance.CurrentInputMovement = jostick.Direction;
        }
    }
}
