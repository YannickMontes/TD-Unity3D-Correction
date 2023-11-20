using UnityEngine;

public class DestroyAllCubesOnEnter : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Cube")
        {
            Destroy(collision.gameObject);
        }
    }
}
