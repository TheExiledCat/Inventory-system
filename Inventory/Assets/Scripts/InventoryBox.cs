using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryBox : MonoBehaviour
{
    int id;
    InventorySlot slot;
    Image imagebox;
    private void Start()
    {
        imagebox = transform.GetChild(0).GetComponent<Image>();
        slot.OnChange += UpdateSlot;
       
    }
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
        UpdateSlot();
    }
    public void UpdateSlot()
    {
        StartCoroutine(UpdateBox());
    }
    IEnumerator UpdateBox()
    {
        yield return new WaitForEndOfFrame();
        
        if (slot.GetItem() != null)
        {
            
            imagebox.sprite = slot.GetItem().icon;
            print(slot.GetItem().itemName);
            print("Updating to sprite " + GetID());
        }
        else
        {
            imagebox.sprite = null;
            print("changing sprite "+GetID()+" to null");
        }

    }
}
