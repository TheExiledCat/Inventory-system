using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InventoryUI : MonoBehaviour
{
    [SerializeField] GameObject inventoryPrefab;
    [SerializeField] GameObject slotPrefab;
    [Range(1,8)]
    [SerializeField] int maxX;
    [SerializeField] int space;
    GameObject currentWindow;
    Canvas canvas;
    bool displaying;
    private void Start()
    {
        canvas = GetComponent<Canvas>();
    }
    private void Update()
    {
        
    }
    public void DrawInventory(Inventory inventory)
    {
        CreateInventoryWindow(inventory);
        displaying = true;
    }
    public void RemoveInventory(Inventory inventory)
    {
        Destroy(currentWindow);
        displaying = false;
    }
    void CreateInventoryWindow(Inventory inventory)
    {
        currentWindow = Instantiate(inventoryPrefab, this.transform);

        currentWindow.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = inventory.GetOwner() + "'s Storage";
        CreateSlots(currentWindow, inventory);
    }
    void CreateSlots(GameObject window, Inventory inventory)
    {
        Vector3 origin = window.transform.GetChild(1).GetChild(0).transform.position;
        for(int j = 0; j < inventory.GetSlots().Count / maxX; j++)
        {
            for (int i = 0; i < maxX; i++)
            {
               
                Instantiate(slotPrefab, origin + Vector3.right * i * space*canvas.scaleFactor + Vector3.down*j*space*canvas.scaleFactor, Quaternion.identity, window.transform);
            }
        }
        
    }
    public bool Displaying(Inventory i)
    {
        return displaying;
    }
}
