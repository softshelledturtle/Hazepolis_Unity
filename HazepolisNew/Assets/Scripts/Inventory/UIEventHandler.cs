using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventHandler : MonoBehaviour
{
    public delegate void ItemEventHandler(Item item);
    public static event ItemEventHandler OnItemAddedToInventory;

    public static void ItemAddedToInventory(Item item)
    {
        if (OnItemAddedToInventory != null)
        {
            OnItemAddedToInventory(item);
            Debug.Log("add to inventory" + item.ItemName);
        }
        //OnItemAddedToInventory?.Invoke(item);
    }
}
