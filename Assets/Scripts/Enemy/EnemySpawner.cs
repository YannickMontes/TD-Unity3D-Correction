using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public BoxCollider spawnBounds = null;
    public Vector2 spawnTime = Vector2.zero;
    public float spawnHeight = 1.0f;
    public float minDistance = 5.0f;
    public GameObject spawnObject = null;

    private GameObject player = null;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(SpawnObject());
    }

    private IEnumerator SpawnObject()
    {
        float randSpawnTime = Random.Range(spawnTime.x, spawnTime.y);
        yield return new WaitForSeconds(randSpawnTime);

        bool farFromPlayer = false;
        Vector3 spawnPos = Vector3.zero;
        while(!farFromPlayer)
        {
            float xSpawn = Random.Range(spawnBounds.bounds.min.x, spawnBounds.bounds.max.x);
            float zSpawn = Random.Range(spawnBounds.bounds.min.z, spawnBounds.bounds.max.z);
            spawnPos = new Vector3(xSpawn, spawnHeight, zSpawn);
            farFromPlayer = Vector3.Distance(spawnPos, player.transform.position) > minDistance;
        }

        Instantiate(spawnObject, spawnPos, Quaternion.identity);
        StartCoroutine(SpawnObject());
    }
}
