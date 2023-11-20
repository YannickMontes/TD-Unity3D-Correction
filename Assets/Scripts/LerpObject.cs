using UnityEngine;

public class LerpObject : MonoBehaviour
{
    public Transform beginPos;
    public Transform endPos;
    public float timeToTravel = 1.0f;
    public bool smoothLerp = false;

    private float elapsedTime = 0.0f;
    private bool reverse = false;

    void Update()
    {
        if(elapsedTime > timeToTravel)
        {
            elapsedTime = 0.0f;
            reverse = !reverse;
        }
        elapsedTime += Time.deltaTime;

        float time = reverse
            ? (timeToTravel - elapsedTime) / timeToTravel
            : elapsedTime / timeToTravel;

        transform.position = smoothLerp
            ? Vector3.Lerp(beginPos.position, endPos.position, time)
            : Vector3.Slerp(beginPos.position, endPos.position, time);
    }
}
