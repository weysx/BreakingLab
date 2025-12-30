using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Na : MonoBehaviour
{
    public GameObject spawnPrefab;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnAtMouse();
            Destroy(gameObject);
        }
    }

    void SpawnAtMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        worldPos.z = 0f;

        Instantiate(spawnPrefab, worldPos, Quaternion.identity);
    }
}
