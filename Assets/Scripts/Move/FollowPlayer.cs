using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float followSpeed = 1.0f;
    public Rigidbody moveBody = null;
    public Animator animator = null;

    private GameObject player = null;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        moveBody.velocity = new Vector3(direction.x * followSpeed, moveBody.velocity.y, direction.z * followSpeed);

        Vector3 sameHeightPlayerPos = player.transform.position;
        sameHeightPlayerPos.y = transform.position.y;
        transform.LookAt(sameHeightPlayerPos);

        if(animator != null)
        {
            animator.SetBool("IsGrounded", true);
            animator.SetFloat("Speed", moveBody.velocity.magnitude);
        }
    }
}
