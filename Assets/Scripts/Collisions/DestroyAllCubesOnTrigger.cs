using UnityEngine;

public class DestroyAllCubesOnTrigger : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
            return;

        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");

        foreach(GameObject cube in cubes)
        {
            Destroy(cube);
        }
    }
}
