using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMetalState : MonoBehaviour
{
    public enum MetalType
    {
        None,
        Li,
        Na,
        K,
        Cs,
        Zn,
        Pb,
        Mn
    }

    [Header("当前金属")]
    public MetalType currentMetal = MetalType.None;

    [Header("颜色设置")]
    public Color normalColor = Color.red;          // 无金属
    public Color liColor = new Color(1f, 0.2f, 0.6f);
    public Color naColor = new Color(1f, 0.8f, 0f);
    public Color kColor = new Color(0.6f, 0.3f, 1f);
    public Color csColor = new Color(0.7f, 0.4f, 1f);
    public Color znColor = new Color(0.5f, 0.8f, 1f);
    public Color pbColor = new Color(0.6f, 0.6f, 1f);
    public Color mnColor = new Color(0.7f, 1f, 0.7f);

    [Header("变色速度")]
    public float colorLerpSpeed = 2f;

    private SpriteRenderer sr;
    private Color targetColor;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        targetColor = normalColor;
    }

    void Update()
    {
        targetColor = GetColorByMetal(currentMetal);

        Color c = sr.color;
        sr.color = Color.Lerp(
            c,
            new Color(targetColor.r, targetColor.g, targetColor.b, c.a),
            Time.deltaTime * colorLerpSpeed
        );
    }

    Color GetColorByMetal(MetalType metal)
    {
        switch (metal)
        {
            case MetalType.Li: return liColor;
            case MetalType.Na: return naColor;
            case MetalType.K: return kColor;
            case MetalType.Cs: return csColor;
            case MetalType.Zn: return znColor;
            case MetalType.Pb: return pbColor;
            case MetalType.Mn: return mnColor;
            default: return normalColor;
        }
    }

    // ===== 给金属调用 =====

    public void EnterMetal(MetalType metal)
    {
        currentMetal = metal;
    }

    public void ExitMetal(MetalType metal)
    {
        if (currentMetal == metal)
        {
            currentMetal = MetalType.None;
        }
    }
}
