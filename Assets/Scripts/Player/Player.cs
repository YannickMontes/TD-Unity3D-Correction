using UnityEngine;
using UnityEngine.SceneManagement;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;

public class Player : MonoBehaviour
{
    public int maxLife = 1;
    public float spawnOffset = 1.0f;
    public GameObject hitFX = null;
    public LayerMask groundLayer;
    public Rigidbody moveBody = null;
    public GroundCheck groundCheck = null;
    public Animator animator = null;

    public int NbEnemiesKilled { get; set; }
    public int CurrentLife { get; private set; }

    private void OnEnable()
    {
        EnhancedTouch.TouchSimulation.Enable();
        EnhancedTouch.EnhancedTouchSupport.Enable();
        EnhancedTouch.Touch.onFingerDown += OnFingerDown;
    }

    private void OnDisable()
    {
        EnhancedTouch.Touch.onFingerDown -= OnFingerDown;
        EnhancedTouch.TouchSimulation.Disable();
        EnhancedTouch.EnhancedTouchSupport.Disable();
    }

    private void Awake()
    {
        CurrentLife = maxLife;
    }

    public void DealDamage(int damage)
    {
        CurrentLife -= damage;
        if(CurrentLife <= 0)
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnFingerDown(EnhancedTouch.Finger finger)
    {
        foreach (EnhancedTouch.Touch touch in EnhancedTouch.Touch.activeTouches)
        {
            if (touch.finger == finger)
            {
            }
            Debug.Log($"Touch screen pos: {touch.screenPosition}");
            Debug.Log($"Start screen pos: {touch.startScreenPosition}");
        }
        Debug.Log(finger.screenPosition);
        Vector2 touchPos = finger.screenPosition;
        if (!UIManager.Instance.IsTouchOnJoystick(touchPos) 
            && touchPos.x >= 0 && touchPos.y >= 0
            && touchPos.x < Screen.width
            && touchPos.y < Screen.height)
        {
            SpawnHitFX(touchPos);
        }
    }

    private void SpawnHitFX(Vector2 screenPos)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPos);
        Debug.Log(ray.origin);
        Debug.Log(ray.direction);
        Debug.DrawRay(ray.origin, ray.direction, Color.blue, 5.0f);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 1000f, groundLayer))
        {
            Vector3 spawnPos = new Vector3(hitInfo.point.x, hitInfo.point.y + spawnOffset, hitInfo.point.z);
            GameObject.Instantiate(hitFX, spawnPos, Quaternion.identity);
        }
    }

    private void Update()
    {
        if(animator != null)
        {
            animator.SetFloat("Speed", moveBody.velocity.magnitude);
            animator.SetBool("IsGrounded", groundCheck.IsGrounded);
        }
    }
}