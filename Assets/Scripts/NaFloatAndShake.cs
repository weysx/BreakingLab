using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaFloatAndShake : MonoBehaviour
{
    public float floatOffsetY = 0.2f;
    public float shakeAmplitude = 0.05f;
    public float shakeSpeed = 12f;

    private bool isFloating = false;
    private Transform water;
    private Vector3 basePos;

    void Update()
    {
        if (!isFloating || water == null) return;

        float xOffset = Mathf.Sin(Time.time * shakeSpeed) * shakeAmplitude;
        transform.position = basePos + new Vector3(xOffset, 0, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("shui"))
        {
            water = collision.collider.transform;
            
            float waterTopY = water.position.y +
                              collision.collider.bounds.extents.y;

            basePos = new Vector3(
                transform.position.x,
                waterTopY + floatOffsetY,
                transform.position.z
            );

            transform.position = basePos;

            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0f;

            isFloating = true;
        }
    }
}
