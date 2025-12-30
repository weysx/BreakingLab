using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsExplode : MonoBehaviour
{
    private bool hasDestroyed = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("shui") && !hasDestroyed)
        {
            DestroyCs();
        }
    }

    void DestroyCs()
    {
        hasDestroyed = true;
        
        // 直接销毁物体
        Destroy(gameObject);
    }
}

