using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsDrop : MonoBehaviour
{
    public GameObject csPrefab; // Cs prefab，用于实例化掉落的Cs

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnCs();
        }
    }

    void SpawnCs()
    {
        // 在当前位置实例化Cs
        Vector3 spawnPos = transform.position;
        spawnPos.z = 0f;
        
        GameObject cs;
        if (csPrefab != null)
        {
            cs = Instantiate(csPrefab, spawnPos, Quaternion.identity);
        }
        else
        {
            // 如果没有设置prefab，动态创建
            cs = CreateCsObject(spawnPos);
        }
        
        // 确保Cs有物理组件并启用重力
        Rigidbody2D rb = cs.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = cs.AddComponent<Rigidbody2D>();
        }
        rb.gravityScale = 1f;
    }

    GameObject CreateCsObject(Vector3 position)
    {
        // 动态创建Cs物体
        GameObject cs = new GameObject("Cs");
        cs.transform.position = position;
        
        // 添加SpriteRenderer
        SpriteRenderer sr = cs.AddComponent<SpriteRenderer>();
        SpriteRenderer cs1Sr = GetComponent<SpriteRenderer>();
        if (cs1Sr != null)
        {
            sr.sprite = cs1Sr.sprite;
            sr.color = new Color(1f, 1f, 1f, 1f); // 不透明
        }
        
        // 添加Collider2D
        CircleCollider2D col = cs.AddComponent<CircleCollider2D>();
        col.radius = 0.2f;
        
        // 添加Rigidbody2D
        Rigidbody2D rb = cs.AddComponent<Rigidbody2D>();
        rb.gravityScale = 1f;
        
        // 添加CsExplode脚本
        cs.AddComponent<CsExplode>();
        
        return cs;
    }
}

