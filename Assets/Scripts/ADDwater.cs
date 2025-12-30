using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADDwater : MonoBehaviour
{
    public GameObject childPrefab;
    private Camera mainCam;
    void Start()
    {
        mainCam = Camera.main;
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TryPlace();
        }
    }
    
    void TryPlace()
    {
        Vector2 mouseWorldPos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);
        if (hit.collider != null && hit.collider.CompareTag("shaobei"))
        {
            GameObject obj = Instantiate(childPrefab, hit.collider.transform);
            obj.transform.position = hit.collider.transform.position;
        }
        Destroy(gameObject);
    }
}
