using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : NPC
{
    public bool AssignedQuest { get; set; }
    public bool Helped { get; set; }

    [SerializeField]
    public GameObject quests;

    //[SerializeField]
    //private string questType;
    private Quest Quest { get; set; }
    public Goal goal;
    public override void Interact()
    {
        if (!AssignedQuest && !Helped)
        {
            base.Interact();
            GiveQuest();
        }
        else if (AssignedQuest && !Helped)
        {
            //CheckQuest();
        }
        else
        {
            Debug.Log("DialogueSystem: Thanks for that");
        }
    }

    public void GiveQuest()
    {
        //AssignedQuest = true;
        //Quest = (Quest)quests.AddComponent(System.Type.GetType(questType));
        if (goal.questStatus == Goal.QuestStatus.Waiting)
        {
            //give quest
            Quest.instance.Goals.Add(goal);
            goal.questStatus = Goal.QuestStatus.Accepted;
        }
        else
        {
            //already has quest
            Debug.Log(string.Format("QUEST:{0} has accepted already", goal.questname));
        }
    }

    //void CheckQuest()
    //{
    //    if (Quest.Completed)
    //    {
    //        Quest.GiveReward();
    //        Helped = true;
    //        AssignedQuest = false;

    //        DialogueSystem.Instance.AddNewDialogue(new string[] { "Thanks for helping", "here you go" }, name);
    //        Debug.Log("DialogueSystem: Thanks");
    //    }
    //    else
    //    {
    //        DialogueSystem.Instance.AddNewDialogue(new string[] { "Thanks for helping", "here you go" }, name);
    //        Debug.Log("DialogueSystem: Still undone");
    //    }
    //}
}
