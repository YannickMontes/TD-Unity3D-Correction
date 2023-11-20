using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int baseDamage = 1;

    public void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponentInParent<Player>();
        if (player != null)
        {
            player.DealDamage(baseDamage);
            Destroy(gameObject);
        }
    }
}
