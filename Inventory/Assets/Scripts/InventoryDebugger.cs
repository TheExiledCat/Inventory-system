using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InventoryDebugger : MonoBehaviour
{
    public Player player;
    Inventory inventory;
    TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
        inventory = player.GetInventory();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Total Slots: " + inventory.GetSlots().Count + "\n";
    }
}
