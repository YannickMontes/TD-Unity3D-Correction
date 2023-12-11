using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int baseDamage = 1;

    private void OnCollisionEnter(Collision collision)
    {
        Player player = collision.gameObject.GetComponentInParent<Player>();
        if (player != null)
        {
            player.DealDamage(baseDamage);
            Destroy(gameObject);
        }
    }
}
