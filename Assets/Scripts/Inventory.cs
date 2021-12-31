using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour{

    [SerializeField]
    private bool open = false;

    private List<Item> items = new List<Item>();
    public IList<Item> Items {
        get {
            return items.AsReadOnly();
        }
    }


    public void AddItem(Item item){
        items.Add(item);
    }

}