using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public Joystick joystick = null;
    public KillCounter killCounter = null;

    private Player player = null;

    private void Start()
    {
        player = FindAnyObjectByType<Player>();
    }

    public bool IsTouchOnJoystick(Vector2 touch)
    {
        RectTransform joystickRect = joystick.transform as RectTransform;
        bool inX = joystickRect.offsetMin.x <= touch.x && touch.x <= joystickRect.offsetMax.x;
        bool inY = joystickRect.offsetMin.y <= touch.y && touch.y <= joystickRect.offsetMax.y;

        return inX && inY;
    }

    private void Update()
    {
        killCounter.SetText(player.NbEnemiesKilled);
    }
}
