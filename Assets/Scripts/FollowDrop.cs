using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowDrop : MonoBehaviour
{
    public GameObject dropPrefab; // 掉落物体的prefab，如果为空则使用当前物体

    void Update()
    {
        // 检测鼠标点击
        if (Input.GetMouseButtonDown(0))
        {
            DropObject();
        }
    }

    void DropObject()
    {
        // 获取当前物体的位置
        Vector3 dropPosition = transform.position;
        
        GameObject droppedObj;
        
        // 如果指定了dropPrefab，使用它；否则复制当前物体
        if (dropPrefab != null)
        {
            droppedObj = Instantiate(dropPrefab, dropPosition, Quaternion.identity);
        }
        else
        {
            // 复制当前物体
            droppedObj = Instantiate(gameObject, dropPosition, Quaternion.identity);
            // 移除FollowDrop脚本，避免新物体也跟随鼠标
            FollowDrop followDrop = droppedObj.GetComponent<FollowDrop>();
            if (followDrop != null)
            {
                Destroy(followDrop);
            }
        }
        
        // 确保物体有物理组件并启用重力
        Rigidbody2D rb = droppedObj.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = droppedObj.AddComponent<Rigidbody2D>();
        }
        rb.gravityScale = 1f;
        
        // 添加DropExplode脚本，用于检测碰撞水并触发烧杯爆炸
        DropExplode dropExplode = droppedObj.GetComponent<DropExplode>();
        if (dropExplode == null)
        {
            droppedObj.AddComponent<DropExplode>();
        }
        
        // 销毁跟随的虚影
        Destroy(gameObject);
    }
}

