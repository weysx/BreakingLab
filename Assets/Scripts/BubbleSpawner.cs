using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public GameObject bubblePrefab;

    public float spawnInterval = 0.25f;
    public Vector2 spawnOffsetRange = new Vector2(0.15f, 0.1f);

    private bool inWater = false;
    private Coroutine bubbleCoroutine;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("shui"))
        {
            if (!inWater)
            {
                inWater = true;
                bubbleCoroutine = StartCoroutine(SpawnBubbles());
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("shui"))
        {
            StopBubbles();
        }
    }

    IEnumerator SpawnBubbles()
    {
        while (inWater)
        {
            Vector3 pos = transform.position;
            pos.x += Random.Range(-spawnOffsetRange.x, spawnOffsetRange.x);
            pos.y += Random.Range(-spawnOffsetRange.y, spawnOffsetRange.y);
            pos.z = -1f;

            Instantiate(bubblePrefab, pos, Quaternion.identity);

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void StopBubbles()
    {
        inWater = false;

        if (bubbleCoroutine != null)
        {
            StopCoroutine(bubbleCoroutine);
            bubbleCoroutine = null;
        }
    }
}
