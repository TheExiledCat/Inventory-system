using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InventoryUI : MonoBehaviour
{
    Dictionary<Storage,GameObject> currentWindows = new Dictionary<Storage, GameObject>();
    [SerializeField] GameObject inventoryPrefab;
    [SerializeField] GameObject chestPrefab;
    [SerializeField] GameObject slotPrefab;
    [Range(1,8)]
    [SerializeField] int maxX;
    [SerializeField] int space;
    Canvas canvas;
    bool displaying;
    private void Start()
    {
        canvas = GetComponent<Canvas>();
    }
    private void Update()
    {
        
    }
    #region ChestUI
    public void DrawChest(Storage storage)
    {
        CreateChestWindow(storage);
    }
    void CreateChestWindow(Storage storage)
    {

        GameObject currentWindow = Instantiate(chestPrefab, transform);
        currentWindows.Add(storage, currentWindow);
        
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
        currentWindows.Add(inventory,currentWindow);
        currentWindow.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = inventory.GetOwner() + "'s Storage";
        Vector3 Origin = currentWindow.transform.GetChild(1).GetChild(0).transform.position;
        CreateSlots(currentWindow, inventory,Origin);
    }
    void CreateSlots(GameObject window, Storage storage,Vector3 Origin)
    {
        
        for(int j = 0; j < storage.GetSlots().Count / maxX; j++)
        {
            for (int i = 0; i < maxX; i++)
            {
               
                Instantiate(slotPrefab, Origin + Vector3.right * i * space*canvas.scaleFactor + Vector3.down*j*space*canvas.scaleFactor, Quaternion.identity, window.transform);
            }
        }
        
    }
    #endregion
    public bool Displaying(Storage i)
    {
        return displaying;
    }

}
