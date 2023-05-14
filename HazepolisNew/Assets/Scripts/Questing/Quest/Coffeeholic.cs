using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffeeholic : Quest
{
    public static Coffeeholic instance;

    private void Awake()
    {
        if (instance == null) { instance = this; }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        Debug.Log("Coffeeholic assigned");

        QuestName = "Coffeeholic";
        QuestRequire = "Coffee";
        QuestReward = "Thank";
        Description = "No coffee, No life.";

        ItemReward = ItemDatabase.Instance.GetItem("coffee_log");
        CoinReward = 100;

        Goals.Add(new CollectionGoal(this, "coffee_log", "Find a Log Coffee.", false, 0, 1));

        Goals.ForEach(g => g.Init());
    }


}
