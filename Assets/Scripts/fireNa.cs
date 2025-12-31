using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireNa : MonoBehaviour
{
    public GameObject childPrefab;

    [Header("生成偏移（本地坐标）")]
    public Vector2 spawnOffset = new Vector2(0f, 0.5f); // 向上偏移

    private GameObject currentLamp;
    private bool isInLamp = false;

    void Update()
    {
        if (isInLamp && Input.GetMouseButtonDown(0))
        {
            SpawnAndDestroy();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Lamp"))
        {
            currentLamp = other.gameObject;
            isInLamp = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Lamp"))
        {
            currentLamp = null;
            isInLamp = false;
        }
    }

    void SpawnAndDestroy()
    {
        if (currentLamp == null) return;

        GameObject child = Instantiate(childPrefab);
        child.transform.SetParent(currentLamp.transform, false);

        // ⭐ 在母物体基础上加偏移
        child.transform.localPosition = new Vector3(
            spawnOffset.x,
            spawnOffset.y,
            0f
        );

        Destroy(gameObject);
    }
}
