using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuoMao : MonoBehaviour
{
     private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnMouseDown()
    {
        // 只响应 Tag 为 Lamp 的物体
        if (!CompareTag("Lamp")) return;

        if (animator == null) return;

        animator.SetTrigger("Takeoff");
    }
}
