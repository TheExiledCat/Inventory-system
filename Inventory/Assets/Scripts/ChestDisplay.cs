using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestDisplay : MonoBehaviour
{
    Chest c;
    public InventoryUI ui;
    // Start is called before the first frame update
    void Start()
    {
        c = GetComponent<Chest>();
        c.OnOpen += OpenChestUI;
        c.OnClose += CloseChestUI;
    }
   
    void OpenChestUI()
    {
        ui.DrawChest(c.GetInventory());
    }
    void CloseChestUI()
    {
        ui.RemoveChest(c.GetInventory());
    }
}
