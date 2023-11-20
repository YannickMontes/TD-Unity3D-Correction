using System.Collections.Generic;
using UnityEngine;

public class PlayerHitFX : MonoBehaviour
{
    private List<Enemy> collideEnemies = new List<Enemy>();

    private void Start()
    {
        Destroy(gameObject, 1.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponentInParent<Enemy>();
        if(enemy != null && !collideEnemies.Contains(enemy))
        {
            collideEnemies.Add(enemy);
            Player player = FindObjectOfType<Player>();
            if(player != null)
                player.NbEnemiesKilled++;
            Destroy(enemy.gameObject);
        }
    }
}
