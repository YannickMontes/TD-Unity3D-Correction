using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnCubeOnMouseClick : MonoBehaviour
{
    public bool spawnOnPlayer = false;
    public GameObject player = null;
    public GameObject toSpawn = null;
    public float ySpawnOffest = 0.5f;

    public InputActionReference clickInputRef = null;

    private void OnEnable()
    {
        clickInputRef.action.performed += OnClick;
    }

    private void OnDisable()
    {
        clickInputRef.action.performed -= OnClick;
    }

    private void OnClick(InputAction.CallbackContext context)
    {
        if (spawnOnPlayer)
        {
            SpawnCubeOnPlayer();
        }
        else
        {
            SpawnOnRaycast();
        }
    }
    
    private void SpawnOnRaycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            Vector3 spawnPos = new Vector3(hitInfo.point.x, hitInfo.point.y + ySpawnOffest, hitInfo.point.z);
            GameObject.Instantiate(toSpawn, spawnPos, Quaternion.identity);
        }
    }

    private void SpawnCubeOnPlayer()
    {
        GameObject.Instantiate(toSpawn, player.transform.position, Quaternion.identity);
    }
}
