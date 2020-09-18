using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] int size;
    Storage storage=new Storage();
    // Start is called before the first frame update
    void Start()
    {
        storage.InitializeSlots(size);
        storage.SetOwner(gameObject.name);
    }
    private void OnMouseDown()
    {
        
    }

}
