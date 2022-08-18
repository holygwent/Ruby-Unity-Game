using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory 
{
    //wydarzenie 
    public event EventHandler OnItemListChanged;

    private List<Item> itemList;
  

    public Inventory()
    {
        //lista itemów
        itemList = new List<Item>();

        AddItem(new Item { itemType = Item.ItemType.BlueVial, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.YellowVial, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.YellowVial, amount = 1 });
        
 
      
   

    }
    //dodaje item
    public void AddItem(Item item)
    {
        if (item.IsStackable())
        {
            bool itemAlreadyInInventory = false;
            foreach (Item inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount += item.amount;
                    itemAlreadyInInventory = true;
                }
            }
            if (!itemAlreadyInInventory)
            {
                itemList.Add(item);
            }
        }
        else
        {
            itemList.Add(item);
        }
   
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItem(Item item)
    {
        if (item.IsStackable())
        {
           Item itemInIventory = null;
            foreach (Item inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount -= 1;
                    itemInIventory = inventoryItem;
                }
            }
            if (itemInIventory != null && itemInIventory.amount <=0)
            {
                itemList.Remove(itemInIventory);
            }
        }
        else
        {
            itemList.Remove(item);
        }

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    //zwraca wszystkie itemy
    public List<Item> GetItemList()
    {
        return itemList;
    }
}
