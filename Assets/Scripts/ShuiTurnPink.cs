using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuiTurnPink : MonoBehaviour
{
    public Color targetColor = new Color(1f, 0.6f, 0.7f);
    public float colorSpeed = 1f;

    private SpriteRenderer sr;
    private bool startChange = false;
    private Color originalColor;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }

    void Update()
    {
        if (!startChange) return;

        Color newColor = Color.Lerp(sr.color, targetColor, Time.deltaTime * colorSpeed);
        newColor.a = originalColor.a;
        sr.color = newColor;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Na"))
        {
            Debug.Log("1");
            startChange = true;
        }
    }
}
