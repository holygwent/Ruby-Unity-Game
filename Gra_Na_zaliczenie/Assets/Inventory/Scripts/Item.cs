using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item 
{
    //lista możliwych typow itemów 
    public enum ItemType
    {
        RedVial,
        BlueVial,
        YellowVial,
        GreenVial
    }
    public ItemType itemType;
    public int amount;

    //zwraca sprite odpowiedni do typu 
    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.RedVial: return ItemAssets.Instance.redVial;
            case ItemType.BlueVial: return ItemAssets.Instance.blueVial;
            case ItemType.YellowVial: return ItemAssets.Instance.yellowVial;
            case ItemType.GreenVial: return ItemAssets.Instance.greenVial;
        }
    }

    //sprawdzanie czy item powinien sie stakować
    public bool IsStackable()
    {
        switch (itemType)
        {
            default:
            case ItemType.RedVial:        
            case ItemType.BlueVial:              
            case ItemType.YellowVial:    
            case ItemType.GreenVial:
                return true;
                //case something not stackable  case ...: return false;
               
           
              
        }
    }
}
