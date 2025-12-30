using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class watercolourchange : MonoBehaviour
{
    [Header("当前状态")]
    public bool hasSuan = false;      // 是否有酸
    public bool hasJian = false;      // 是否有碱
    public bool hasZhishi = false;    // 是否有指示剂

    [Header("颜色设置")]
    public Color acidColor = Color.green;   // 指示剂 + 酸 → 绿
    public Color baseColor = Color.blue;    // 默认 → 蓝
    public Color alkaliColor = Color.red;   // 指示剂 + 碱 → 红

    [Header("颜色变化速度")]
    public float colorChangeSpeed = 2f;

    private SpriteRenderer sr;
    private Color targetColor;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        targetColor = baseColor;
    }

    void Update()
    {
        UpdateTargetColor();

        // 缓慢变色（不改透明度）
        Color current = sr.color;
        Color next = Color.Lerp(
            current,
            new Color(targetColor.r, targetColor.g, targetColor.b, current.a),
            Time.deltaTime * colorChangeSpeed
        );
        sr.color = next;
    }

    void UpdateTargetColor()
    {
        // 酸碱同时存在 → 相互抵消
        if (hasSuan && hasJian)
        {
            hasSuan = false;
            hasJian = false;
        }

        // 指示剂 + 酸
        if (hasZhishi && hasSuan)
        {
            targetColor = acidColor;
            return;
        }

        // 指示剂 + 碱
        if (hasZhishi && hasJian)
        {
            targetColor = alkaliColor;
            return;
        }

        // 只有指示剂 或 什么都没有
        targetColor = baseColor;
    }

    // ====== 供外部调用的方法 ======

    public void EnterSuan()
    {
        hasSuan = true;
    }

    public void EnterJian()
    {
        hasJian = true;
    }

    public void EnterZhishi()
    {
        hasZhishi = true;
    }
}
