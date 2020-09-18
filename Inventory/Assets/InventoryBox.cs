using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBox : MonoBehaviour
{
    int id;
    InventorySlot slot;
    public int GetID()
    {
        return id;
    }
    public void SetID(int _id)
    {
        id = _id;
    }
    public InventorySlot GetSlot()
    {
        return slot;
    }
    public void SetSlot(InventorySlot _slot)
    {
        slot = _slot;
    }

}
