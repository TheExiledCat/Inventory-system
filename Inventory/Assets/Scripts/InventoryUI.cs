using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InventoryUI : MonoBehaviour
{
    public static InventoryUI UI = null;
    enum sortingOrder
    {
        ALPHABET_UP,
        ALPHABET_DOWN,
    }
    sortingOrder order;
    Dictionary<Storage, GameObject> currentWindows = new Dictionary<Storage, GameObject>();
    Dictionary<InventorySlot, Storage> loadedSlots = new Dictionary<InventorySlot, Storage>();
    [SerializeField] GameObject inventoryPrefab;
    [SerializeField] GameObject chestPrefab;
    [SerializeField] GameObject slotPrefab;
    [Range(1, 8)]
    [SerializeField] int maxX;
    [SerializeField] int space;
    Canvas canvas;
    bool displaying;
    InventoryBox lastHovered;
    private void Awake()
    {
        if (InventoryUI.UI == null)
        {
            DontDestroyOnLoad(this);
            InventoryUI.UI = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }




    private void Start()
    {
        canvas = GetComponent<Canvas>();
    }

    #region ChestUI
    public void DrawChest(Storage storage)
    {
        if (!currentWindows.ContainsKey(storage))
            CreateChestWindow(storage);
    }
    void CreateChestWindow(Storage storage)
    {

        GameObject currentWindow = Instantiate(chestPrefab, transform);
        currentWindows.Add(storage, currentWindow);
        currentWindow.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = storage.GetOwner() + "'s Storage";
        CreateSlots(currentWindows[storage], storage, currentWindow.transform.GetChild(1).GetChild(0).position);
    }
    public void RemoveChest(Storage storage)
    {
        GameObject slotToDestroy = currentWindows[storage];
        currentWindows.Remove(storage);

        Destroy(slotToDestroy);
    }
    #endregion
    #region Inventory UI
    public void DrawInventory(Inventory inventory)
    {
        CreateInventoryWindow(inventory);
        displaying = true;
    }
    public void RemoveInventory(Inventory inventory)
    {
        Destroy(currentWindows[inventory]);
        currentWindows.Remove(inventory);
        displaying = false;
    }
    void CreateInventoryWindow(Inventory inventory)
    {
        GameObject currentWindow = Instantiate(inventoryPrefab, transform);
        currentWindows.Add(inventory, currentWindow);
        currentWindow.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = inventory.GetOwner() + "'s Storage";
        Vector3 Origin = currentWindow.transform.GetChild(1).GetChild(0).transform.position;
        CreateSlots(currentWindow, inventory, Origin);
    }
    #endregion
    void CreateSlots(GameObject window, Storage storage, Vector3 Origin)
    {

        int iterator = 0;
        for (int j = 0; j < storage.GetSlots().Count / maxX; j++)
        {
            for (int i = 0; i < maxX; i++)
            {
                GameObject newSlot = Instantiate(slotPrefab, Origin + Vector3.right * i * space * canvas.scaleFactor + Vector3.down * j * space * canvas.scaleFactor, Quaternion.identity, window.transform);
                InventoryBox box = newSlot.GetComponent<InventoryBox>();
                box.SetID(iterator);

                box.SetSlot(storage.GetSlots()[iterator]);
                loadedSlots.Add(box.GetSlot(), storage);

                iterator++;
            }
        }

    }
    public void SetLastHovered(InventoryBox last)
    {
        lastHovered = last;
    }
    public InventoryBox GetLastHovered()
    {
        return lastHovered;
    }
    public bool Displaying(Storage i)
    {
        return displaying;
    }
    public void SwapItemsInInventory(InventoryBox a, InventoryBox b)
    {
        Storage s_a = loadedSlots[a.GetSlot()];
        Storage s_b = loadedSlots[b.GetSlot()];
        s_a.Swap(a.GetID(), b.GetID(), s_b);

        a.UpdateSlot();
        b.UpdateSlot();
        print("swapping: " + a.GetID() + " from storage: " + s_a.GetOwner() + "\n"
            + "with: " + b.GetID() + " from storage: " + s_b.GetOwner());
    }
    public void ChangeSort()
    {
        if (order == sortingOrder.ALPHABET_UP) order = sortingOrder.ALPHABET_DOWN;
        else order = sortingOrder.ALPHABET_UP;
        
    } 
}
