using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public static InventoryController Instance { get; set; }
    public ConsumableController consumableController;
    public InventoryUIDetails inventoryUIDetailsPanel;
    public List<Item> playerItems = new List<Item>();

    private void Start()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;

        consumableController = GetComponent<ConsumableController>();
        GiveItem("coffee_log");
    }

    public void GiveItem(string itemSlug)
    {
        Item item = ItemDatabase.Instance.GetItem(itemSlug);
        playerItems.Add(item);
        Debug.Log(playerItems.Count + "items in inventory. Add:" + itemSlug);
        UIEventHandler.ItemAddedToInventory(item); 
    }


    public void SetItemDetails(Item item, Button selectedButton)
    {
        inventoryUIDetailsPanel.SetItem(item, selectedButton);
    }
    public void EquiptItem()
    {
        //PlayerWeaponController
    }

    public void ConsumeItem(Item itemToconsume)
    {
        consumableController.ConsumeItem(itemToconsume);
    }
}
