using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CodeMonkey.Utils;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;
    private Transform background;
    private InventoryMixing mix;


    private void Awake()
    {
        //szukanie "itemSlotTemplate"
        itemSlotContainer = transform.Find("itemSlotContainer");
        background = transform.Find("background");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");


         mix = new InventoryMixing();
        
    }
    //wys³anie mix zeby uzyskac w  klasie RubyController mozliwosci ustawienia playera
    public InventoryMixing SendMixReference()
    {
        return mix; 
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        mix.SetInventory(this.inventory);
        //wydarzenie ktore refreshuje ekwipunek
        inventory.OnItemListChanged += Inventory_OnItemListChanged;

        RefreshInventoryItems();
    }
    
    //refresh ekwipunka przy zmianie
    private void Inventory_OnItemListChanged(object sender,System.EventArgs e)
    {
        RefreshInventoryItems();
    }


    //ustawia itemy w  ekwipunku
    private void RefreshInventoryItems()
    {
        // wykonanie funkcji podczas wcisniecia prawego przycisku myszki na ekwipunku
        background.GetComponent<Button_UI>().MouseRightClickFunc = () =>
        {

            mix.StopMixing();
        };

        foreach (Transform child in itemSlotContainer)
        {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }

        //polo¿enie startowe itemów
        float x = 0f;
        float y = 0.45f;
        float itemSlotCellSize = 45f;//rozmiar itemu
        foreach (Item item in inventory.GetItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            //wykonywanie funkcji podczas wciœniêcia lewego przycisku myszki
            itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () => {
              

                mix.ChooseToMix(item);
            };
            // wykonanie funkcji podczas wcisniecia prawego przycisku myszki na iconie
            itemSlotRectTransform.GetComponent<Button_UI>().MouseRightClickFunc = () =>
            {

                mix.StopMixing();
            };

            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();//znalezienie szablonu itemu z canvas
            image.sprite = item.GetSprite();//danie itemowi odpowiedniego zdjecia
            TextMeshProUGUI uiText = itemSlotRectTransform.Find("amountText").GetComponent<TextMeshProUGUI>();
            if (item.amount > 1 )
            {
                uiText.SetText(item.amount.ToString());

            }
            else
            {
                uiText.SetText("");
            }
            x=x+1.5f;//przemieszczenie itemy w ekwipunku
           
        }
    }
}
