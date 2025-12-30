using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suanjianzhishi : MonoBehaviour
{
    [Header("�������")]
    public float gravityScale = 1f;
    public float maxFallSpeed = -3f;

    private Rigidbody2D rb;
    private bool enteredWater = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;
    }

    void FixedUpdate()
    {
        if (rb.velocity.y < maxFallSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, maxFallSpeed);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (enteredWater) return;

        if (!other.CompareTag("shui")) return;

        watercolourchange shui =
            other.GetComponent<watercolourchange>();

        if (shui != null)
        {
            if (CompareTag("suan"))
            {
                shui.EnterSuan();
            }
            else if (CompareTag("jian"))
            {
                shui.EnterJian();
            }
            else if (CompareTag("zhishi"))
            {
                shui.EnterZhishi();
            }
        }

        enteredWater = true;
        AfterEnterWater();
    }

    void AfterEnterWater()
    {
        rb.velocity = Vector2.zero;
        rb.gravityScale = 0f;
        
        Destroy(gameObject, 0.1f);
    }
}
