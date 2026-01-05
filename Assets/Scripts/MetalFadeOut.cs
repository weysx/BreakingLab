using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalFadeOut : MonoBehaviour
{
    public float disappearTime = 2f; // 完全消失所需时间

    SpriteRenderer sr;
    float timer = 0f;
    Vector3 startScale;
    Color startColor;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        startScale = transform.localScale;
        startColor = sr.color;
    }

    void Update()
    {
        timer += Time.deltaTime;
        float t = timer / disappearTime;

        // 透明度变小
        Color c = startColor;
        c.a = Mathf.Lerp(startColor.a, 0f, t);
        sr.color = c;

        // 体积变小
        transform.localScale = Vector3.Lerp(startScale, Vector3.zero, t);

        // 自毁
        if (t >= 1f)
        {
            Destroy(gameObject);
        }
    }
}
