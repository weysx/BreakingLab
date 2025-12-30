using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropExplode : MonoBehaviour
{
    public GameObject cupBoomPrefab; // 烧杯爆炸的prefab，如果为空则尝试查找场景中的烧杯并播放动画
    public Vector3 positionOffset = Vector3.zero; // 位置偏移量，用于微调爆炸位置
    private bool hasExploded = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("shui") && !hasExploded)
        {
            Debug.Log("Cs遇水爆炸");
            hasExploded = true;
            ExplodeCup();
            // 销毁掉落的物体
            Destroy(gameObject);
        }
    }

    void ExplodeCup()
    {
        // 查找场景中的烧杯
        GameObject cup = GameObject.FindGameObjectWithTag("shaobei");
        
        if (cup != null)
        {
            // 如果指定了爆炸prefab，实例化它
            if (cupBoomPrefab != null)
            {
                // 获取烧杯的位置
                Vector3 cupPosition = cup.transform.position;
                
                // 获取爆炸prefab根对象的偏移量（爆炸prefab的根对象有偏移）
                // 需要减去这个偏移量来对齐位置
                Transform boomRoot = cupBoomPrefab.transform;
                Vector3 boomOffset = boomRoot.localPosition;
                
                // 调整位置：使用烧杯位置减去爆炸prefab的偏移量，再加上用户设置的偏移量
                Vector3 explosionPosition = cupPosition - boomOffset + positionOffset;
                
                Quaternion cupRotation = cup.transform.rotation;
                Instantiate(cupBoomPrefab, explosionPosition, cupRotation);
                
                // 隐藏或销毁原烧杯
                cup.SetActive(false);
            }
            else
            {
                // 尝试播放烧杯的爆炸动画
                Animator animator = cup.GetComponent<Animator>();
                if (animator != null)
                {
                    animator.Play("boom");
                }
                else
                {
                    // 如果没有Animator，尝试查找子对象中的Animator
                    animator = cup.GetComponentInChildren<Animator>();
                    if (animator != null)
                    {
                        animator.Play("boom");
                    }
                }
            }
        }
    }
}


