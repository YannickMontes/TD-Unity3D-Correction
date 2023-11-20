using System.Collections;
using UnityEngine;

public class FollowAnimationCurve : MonoBehaviour
{
    public AnimationCurve moveOverTime = null;
    public Transform beginPos = null;
    public Transform endPos = null;

    private Coroutine followRoutine = null;
    
    public void StartFollow()
    {
        if(followRoutine == null)
        {
            followRoutine = StartCoroutine(FollowRoutine());
        }
    }

    public void StopFollow()
    {
        if(followRoutine != null)
        {
            StopCoroutine(followRoutine);
            followRoutine = null;
        }
    }

    private IEnumerator FollowRoutine()
    {
        float elapsedTime = 0.0f;
        while(!IsCurveFinished(elapsedTime))
        {
            elapsedTime += Time.deltaTime;
            float lerpTime = moveOverTime.Evaluate(elapsedTime);
            Vector3 newPos = Vector3.Lerp(beginPos.position, endPos.position, lerpTime);
            transform.position = newPos;
            yield return null;
        }
        followRoutine = null;
    }

    public bool IsCurveFinished(float time)
    {
        return moveOverTime.keys[moveOverTime.keys.Length - 1].time <= time;
    }
}
