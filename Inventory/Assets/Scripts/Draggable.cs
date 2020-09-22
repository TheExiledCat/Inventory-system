using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    
    bool dragging = false;
    RectTransform trans;
    private void Start()
    {
        trans = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (dragging)
        {
            transform.position = Input.mousePosition-(Vector3.up*trans.sizeDelta.y/2);
            print("click");
        }
    }
    public void Drag()
    {
        dragging = true;
        

    }
    public void StopDrag()
    {
        dragging = false;
    }

}
