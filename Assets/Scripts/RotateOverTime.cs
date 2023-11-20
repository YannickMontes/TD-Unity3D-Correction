using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOverTime : MonoBehaviour
{
    public Vector3 speedByAxis = Vector3.zero;

    void Update()
    {
        transform.Rotate(Vector3.right, speedByAxis.x * Time.deltaTime);
        transform.Rotate(Vector3.up, speedByAxis.y * Time.deltaTime);
        transform.Rotate(Vector3.forward, speedByAxis.z * Time.deltaTime);
    }
}
