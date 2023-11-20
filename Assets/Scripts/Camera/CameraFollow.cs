using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target = null;
    public float smoothFollowSpeed = 0.0f;
    public Vector3 offset = Vector3.zero;

    private Vector3 currentSmoothVector = Vector3.zero;

    private void Start()
    {
        currentSmoothVector = transform.position;
    }

    public void LateUpdate()
    {
        Vector3 destination = target.transform.position + offset;
        Vector3 nextCamPos = Vector3.SmoothDamp(transform.position, destination, ref currentSmoothVector, smoothFollowSpeed);
        transform.position = nextCamPos;
    }
}
