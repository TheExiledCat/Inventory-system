using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    UnitStats stats = new UnitStats(10,10,100,100,5,5,10);
    Inventory backpack= new Inventory("Amano",30, 10,4);
    public event Action OnOpenBackpack;
    public event Action OnCloseBackpack;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            OpenBackpack();
        }
    }
    void OpenBackpack()
    {
        OnOpenBackpack?.Invoke();
    }
    void CloseBackpack()
    {
        OnCloseBackpack?.Invoke();
    }
    public Inventory GetInventory()
    {
        return backpack;
    }
}
