using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float lifeTime = 1.2f;
    public float startScale = 1f; 
    public float endScale = 0.1f; 
    public float riseSpeed = 0.5f; 

    private float timer = 0f;
    private SpriteRenderer sr;
    private Color startColor;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        startColor = sr.color;
        transform.localScale = Vector3.one * startScale;
    }

    void Update()
    {
        timer += Time.deltaTime;
        transform.position += Vector3.up * riseSpeed * Time.deltaTime;
        float t = timer / lifeTime;
        float scale = Mathf.Lerp(startScale, endScale, t);
        transform.localScale = Vector3.one * scale;
        Color c = startColor;
        c.a = Mathf.Lerp(startColor.a, 0f, t);
        sr.color = c;

        if (timer >= lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
