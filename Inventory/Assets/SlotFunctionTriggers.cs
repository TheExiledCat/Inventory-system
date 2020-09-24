using System;
using System.Collections.Generic;
using UnityEngine;

public class SlotFunctionTriggers : MonoBehaviour
{
    InventoryBox b;
    private void Start()
    {
        b = GetComponent<InventoryBox>();
    }
    public void Drag()
    {
        
        //InventoryUI.UI.
        print("Dragging on " + b.GetID());
    }
    public void Drop()
    {
        InventoryUI.UI.SwapItemsInInventory(b, InventoryUI.UI.GetLastHovered());
        print("Dropping on " + b.GetID());
    }
    public void Hover()
    {
        InventoryUI.UI.SetLastHovered(b);
        print("Hovering on " + b.GetID());
    }
}
