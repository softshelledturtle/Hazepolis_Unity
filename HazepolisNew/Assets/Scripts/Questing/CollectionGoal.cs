using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionGoal : Goal
{
    public string ItemID { get; set; }
    public CollectionGoal(Quest quest,string itemID, string description, bool completed, int currentAmount, int requiredAmount)
    {
        this.Quest = quest;
        this.ItemID = itemID;
        this.Description = description;
        this.Completed = completed;
        this.CurrentAmount = currentAmount;
        this.RequiredAmount = requiredAmount;
    }

    public override void Init()
    {
        base.Init();
        UIEventHandler.OnItemAddedToInventory += IremPickedUp;
    }

    void IremPickedUp(Item item)
    {
        if(item.ObjectSlug == this.ItemID)
        {
            Debug.Log("Detectrd required item" + ItemID);
            this.CurrentAmount++;
            Evaluate();
        }
    }
}
