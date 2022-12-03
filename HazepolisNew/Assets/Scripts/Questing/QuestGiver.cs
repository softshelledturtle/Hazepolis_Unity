using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : NPC
{
    public bool AssignedQuest { get; set; }
    public bool Helped { get; set; }

    [SerializeField]
    private GameObject quests;

    [SerializeField]
    private string questType;
    private Quest Quest { get; set; }
    public override void Interact()
    {
        if(!AssignedQuest && !Helped)
        {
            base.Interact();
            AssignQuest();
        }
        else if(AssignedQuest && !Helped)
        {
            CheckQuest();
        }
        else
        {
            Debug.Log("DialogueSystem: Thanks for that");
        }
    }

    void AssignQuest()
    {
        AssignedQuest = true;
        Quest = (Quest)quests.AddComponent(System.Type.GetType(questType));
    }

    void CheckQuest()
    {
        if (Quest.Completed)
        {
            Quest.GiveReward();
            Helped = true;
            AssignedQuest = false;
            Debug.Log("DialogueSystem: Thanks");
        }
        else
        {
            Debug.Log("DialogueSystem: Still undone");
        }
    }
}
