using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class girl : Quest
{
    private void Start()
    {
        Debug.Log("girl assigned");
        QuestName = "girl";

        QuestRequire = "0";
        QuestReward = "0";
        Description = "0";

        ItemReward = ItemDatabase.Instance.GetItem("coffee_log");
        CoinReward = 100;

        Goals.Add(new CollectionGoal(this, "coffee_log", "Find a Log Coffee.", 0, 1));

        Goals.ForEach(g => g.Init());
    }
}
