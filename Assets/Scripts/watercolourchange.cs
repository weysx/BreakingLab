using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class watercolourchange : MonoBehaviour
{
  [Header("��ǰ״̬")]
    public bool hasSuan = false;
    public bool hasJian = false;
    public bool hasZhishi = false;
    public bool hasNaCO3 = false;

    [Header("��ɫ����")]
    public Color acidColor = Color.green;
    public Color baseColor = Color.blue;
    public Color alkaliColor = Color.red;

    [Header("��ɫ�仯�ٶ�")]
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

        Color current = sr.color;
        Color next = Color.Lerp(
            current,
            new Color(targetColor.r, targetColor.g, targetColor.b, current.a),
            Time.deltaTime * colorChangeSpeed
        );
        sr.color = next;

        CheckNaCO3Reaction();
    }

    void UpdateTargetColor()
    {
        if (hasSuan && hasJian)
        {
            hasSuan = false;
            hasJian = false;
        }

        if (hasZhishi && hasSuan)
        {
            targetColor = acidColor;
            return;
        }

        if (hasZhishi && hasJian)
        {
            targetColor = alkaliColor;
            return;
        }

        targetColor = baseColor;
    }

    // ===== �ؼ������ NaCO3 + �� =====
    void CheckNaCO3Reaction()
    {
        if (hasSuan && hasNaCO3)
        {
            // �ҵ�ˮ�е� NaCO3��������Ӧ
            NaCO3Reaction[] list = FindObjectsOfType<NaCO3Reaction>();
            foreach (var na in list)
            {
                na.StartReaction();
            }

            // ��ֹ�ظ�����
            hasNaCO3 = false;
        }
    }

    // ===== �ⲿ���� =====
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

    public void EnterNaCO3()
    {
        hasNaCO3 = true;
    }
}
