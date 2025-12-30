using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public GameObject prefab;
    private GameObject currentObj;
    private bool isPlacing = false;

    void Update()
    {
        if (!isPlacing || currentObj == null) return;
        FollowMouse();
    }
    
    public void OnButtonClick()
    {
        if (isPlacing)
        {
            CancelPlacing();
        }

        StartPlacing();

    }

    void StartPlacing()
    {
        currentObj = Instantiate(prefab);
        isPlacing = true;
    }

    void CancelPlacing()
    {
        if (currentObj != null)
        {
            Destroy(currentObj);
        }
        isPlacing = false;
    }

    void FollowMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.WorldToScreenPoint(Vector3.zero).z;

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        currentObj.transform.position = worldPos;
    }
}
