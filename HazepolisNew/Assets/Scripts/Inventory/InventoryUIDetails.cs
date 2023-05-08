using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIDetails : MonoBehaviour
{
    Item item;
    Image itemBigImage;
    Button selectedItemButton, itemInteractButton;
    Text itemNameText, itemDescriptionText, itemInteractButtonTaxt;

    public Text statText;

    private void Start()
    {
        itemBigImage = transform.Find("Item_Image").GetComponent<Image>();
        itemNameText = transform.Find("Item_Name").GetComponent<Text>();
        itemDescriptionText = transform.Find("Item_Description").GetComponent<Text>();
        itemInteractButton = transform.Find("Button").GetComponent<Button>();
        itemInteractButtonTaxt = itemInteractButton.transform.Find("Text").GetComponent<Text>();
        gameObject.SetActive(false);
    }
    public void SetItem(Item item, Button selectedButton)
    {
        gameObject.SetActive(true);
        statText.text = "";
        if(item.Stats != null)
        {
            foreach (BaseStat stat in item.Stats)
            {
                statText.text += stat.StatName + ": " + stat.BaseValue + "\n";
            }
        }
        this.item = item;
        itemBigImage.sprite = Resources.Load<Sprite>("UI/Icons/Items/" + item.ObjectSlug);

        selectedItemButton = selectedButton;
        itemNameText.text = item.ItemName;
        itemDescriptionText.text = item.Description;
        itemInteractButtonTaxt.text = item.ActionName;
        itemInteractButton.onClick.AddListener(OnItemInteract);
    }

    public void OnItemInteract()
    {
        if(item.ItemType == Item.ItemTypes.Consumable)
        {
            InventoryController.Instance.ConsumeItem(item);
            Destroy(selectedItemButton.gameObject);
        }
        if (item.ItemType == Item.ItemTypes.Quest)
        {
            InventoryController.Instance.UseQuestItem(item);
        }
        item = null;
        gameObject.SetActive(false);
    }
}
