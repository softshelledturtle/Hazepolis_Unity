using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TALK : Quest
{
    public static new TALK instance;

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
        DontDestroyOnLoad(transform.root.gameObject);
    }
    private void Start()
    {
        Debug.Log("TALK assigned");

        QuestName = "Talk";
        QuestRequire = "none";
        QuestReward = "Thank";
        Description = "test";

        //Goals.Add(new CollectionGoal(this, "coffee_log", "Find a Log Coffee.", false, 0, 1));

        //Goals.ForEach(g => g.Init());
    }
}
