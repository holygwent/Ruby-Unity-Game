using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMixing 
{
    //2 vial
    private Item itemToMix { get; set; }
    private  Item itemToMix2 { get; set; }

    private RubyController player;
    private Inventory inventory;
   private GameObject[] PushRocks;
 
    public InventoryMixing()
    {
         PushRocks =  GameObject.FindGameObjectsWithTag("PushRock");
       
    }
   

    public void SetInventory (Inventory inventory)
    {
        this.inventory = inventory;
    }

   
    public void SetPlayer(RubyController player)
    {
        this.player = player;
        
    }

   public void FinishMixing()
    {
        
        itemToMix = null;
        itemToMix2 = null;
    }
    public void ChooseToMix(Item item)
    {
        Item copyItem = new Item {itemType = item.itemType , amount = 1};
      
       
        if (itemToMix == null & itemToMix2 == null)
        {
            this.itemToMix = copyItem;
           
            inventory.RemoveItem(itemToMix);
            Debug.Log("pierwsza fiolka"+itemToMix.itemType);
           
        }
        else 
        {
            this.itemToMix2 = copyItem;
           
            inventory.RemoveItem(itemToMix2);
            Debug.Log("druga fiolka"+itemToMix2.itemType);
           
            Mix();
            
        }
    }
    //mieszanie fiolek wedlug itemType
    public void Mix()
    {
        
       
        if (itemToMix.itemType is Item.ItemType.YellowVial & itemToMix2.itemType is Item.ItemType.YellowVial )
        {
            Debug.Log("polaczyles zolta i zolta fiolke czyli mikstura sily");
            Mixture mixture = new Mixture(Mixture.MixtureType.Strength);
            player.UseMixture(mixture);
            foreach (var rock in PushRocks)
            {
                rock.gameObject.layer = 0;
            }

            FinishMixing();
            
           
           
        }
        else if(itemToMix.itemType is Item.ItemType.GreenVial & itemToMix2.itemType is Item.ItemType.GreenVial)
        {
            Debug.Log("test levitation");
            Mixture mixture = new Mixture(Mixture.MixtureType.Levitation);
            player.UseMixture(mixture);
            FinishMixing();
        }
        else
        {
            WrongMixing();
        }
    }

    public void StopMixing()
    {
        if (itemToMix != null)
        {
            inventory.AddItem(itemToMix);
            itemToMix = null;
        }
        
    }
    public void WrongMixing()
    {
        if (itemToMix != null & itemToMix2 != null)
        {
            inventory.AddItem(itemToMix);
            inventory.AddItem(itemToMix2);
            itemToMix = null;
            itemToMix2 = null;
        }
        
       
    }
}
