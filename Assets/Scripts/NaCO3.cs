using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaCO3 : MonoBehaviour
{
[Header("�������")]
    public float gravityScale = 1f;   // ����ǿ��
    public float maxFallSpeed = -3f;  // ��������ٶȣ���ֵ��

    private Rigidbody2D rb;
    private bool enteredWater = false;
    [Header("����ˮ���³�")]
    public float sinkDistance = 0.1f;   // �³�����
    public float sinkTime = 0.3f;       // �³�ʱ��
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;
    }

    void FixedUpdate()
    {
        // ������������ٶ�
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
            // ͨ���������� Tag���ж���ʲô����
            if (CompareTag("NaCO3"))
            {
                shui.EnterNaCO3();
            }
           
        }

        enteredWater = true;
        AfterEnterWater();
    }
    IEnumerator SinkDown()
    {
        Vector3 startPos = transform.position;
        Vector3 targetPos = startPos + Vector3.down * sinkDistance;

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / sinkTime;
            transform.position = Vector3.Lerp(startPos, targetPos, t);
            yield return null;
        }

        transform.position = targetPos;
    }
    void AfterEnterWater()
    {
        rb.velocity = Vector2.zero;
        rb.gravityScale = 0f;

        StartCoroutine(SinkDown());
    }
}
