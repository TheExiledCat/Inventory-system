using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplayer : MonoBehaviour
{
    public InventoryUI ui;
    Player p;
    // Start is called before the first frame update
    void Start()
    {
        p = GetComponent<Player>();
        p.OnOpenBackpack += DisplayInventory;
        p.OnCloseBackpack += HideInventory;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DisplayInventory()
    {
        if (!ui.Displaying(p.GetInventory())){
            ui.DrawInventory(p.GetInventory());
        }
        else
        {
            HideInventory();
        }
    }
    void HideInventory()
    {
        
            ui.RemoveInventory(p.GetInventory());
        
    }
}
