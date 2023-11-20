using UnityEngine;

public class ActivateFollowOnTrigger : MonoBehaviour
{
    public bool activate = true;
    public FollowAnimationCurve cubeFollow = null;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (activate)
                cubeFollow?.StartFollow();
            else
                cubeFollow?.StopFollow();
        }
    }
}
