using UnityEngine;

public class InputManager : MonoBehaviour
{
    public bool readMovementFromKeyboard = true;
    public ReadMovementInput readMovementInput = null;

    private static InputManager instance;

    public static InputManager Instance { get { return instance; } }
    public Vector2 CurrentInputMovement { get; set; } = Vector2.zero;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if(readMovementFromKeyboard)
        {
            CurrentInputMovement = readMovementInput.CurrentMovementInput;
        }
    }
}
