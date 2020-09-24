using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Item", menuName = "Create New Item", order = 1)]

public class Item : ScriptableObject
{
    public string itemName;
    public string description;
    public int maxStackAmount;
    public Sprite icon;
    
}
