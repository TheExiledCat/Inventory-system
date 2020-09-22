using System;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{

    [SerializeField] int size;
    Storage storage=new Storage();
    public event Action OnOpen;
    // Start is called before the first frame update
    void Start()
    {
        storage.InitializeSlots(size);
        storage.SetOwner(gameObject.name);
    }
    private void OnMouseDown()
    {
        OnOpen();
    }
    public Storage GetInventory()
    {
        return storage;
    }
    public void SetInventory(List<InventorySlot> s)
    {
        storage.SetSlots(s);
    }

}
