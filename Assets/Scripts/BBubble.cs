using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBubble : MonoBehaviour
{
     public GameObject bubblePrefab;
    public float spawnInterval = 0.25f;
    public Vector2 spawnOffsetRange = new Vector2(0.15f, 0.1f);

    private Coroutine bubbleCoroutine;

    public void StartBubble()
    {
        if (bubbleCoroutine == null)
        {
            bubbleCoroutine = StartCoroutine(SpawnBubbles());
        }
    }

    public void StopBubble()
    {
        if (bubbleCoroutine != null)
        {
            StopCoroutine(bubbleCoroutine);
            bubbleCoroutine = null;
        }
    }

    IEnumerator SpawnBubbles()
    {
        while (true)
        {
            Vector3 pos = transform.position;
            pos.x += Random.Range(-spawnOffsetRange.x, spawnOffsetRange.x);
            pos.y += Random.Range(-spawnOffsetRange.y, spawnOffsetRange.y);
            pos.z = -1f;

            Instantiate(bubblePrefab, pos, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
