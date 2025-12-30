using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaCO3Reaction : MonoBehaviour
{
    [Header("��С����")]
    public float shrinkTime = 2f;
    public float minScale = 0.1f;

    private bool reacting = false;
    private BBubble bubble;

    void Awake()
    {
        bubble = GetComponent<BBubble>();
    }

    public void StartReaction()
    {
        if (reacting) return;

        reacting = true;

        if (bubble != null)
        {
            bubble.StartBubble();
        }

        StartCoroutine(ShrinkAndDestroy());
    }

    IEnumerator ShrinkAndDestroy()
    {
        Vector3 startScale = transform.localScale;
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime / shrinkTime;
            transform.localScale = Vector3.Lerp(startScale, Vector3.one * minScale, t);
            yield return null;
        }

        Destroy(gameObject);
    }
}
