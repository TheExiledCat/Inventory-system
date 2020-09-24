using System;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{

    [SerializeField] int size;
    [SerializeField]Storage storage=new Storage();
    public event Action OnOpen;
    public event Action OnClose;
    public Item itemToUse;
    public Item itemToUse2;
    // Start is called before the first frame update
    void Start()
    {
        storage.InitializeSlots(size);
        storage.SetOwner(gameObject.name);
        storage.Fill(itemToUse,itemToUse2);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            OnClose?.Invoke();
        }
    }
    private void OnMouseDown()
    {
        OnOpen?.Invoke();
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
