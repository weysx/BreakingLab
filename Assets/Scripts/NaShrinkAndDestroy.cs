using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaShrinkAndDestroy : MonoBehaviour
{
    public float shrinkSpeed = 0.4f;
    public float minScale = 0.1f;

    private bool startShrink = false;

    void Update()
    {
        if (!startShrink) return;

        transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;

        if (transform.localScale.x <= minScale)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("shui"))
        {
            startShrink = true;
        }
    }
}
