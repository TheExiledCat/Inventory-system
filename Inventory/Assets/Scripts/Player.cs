using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    UnitStats stats = new UnitStats(10,10,100,100,5,5,10);
    [SerializeField]
    Inventory backpack;
    public event Action OnOpenBackpack;
    public event Action OnCloseBackpack;
    private void Awake()
    {
        backpack= new Inventory(stats, "Amano", 30, 10, 4);
    }
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
