using UnityEngine;

[System.Serializable]
public class Goal 
{
    public Quest Quest { get; set; }

    
    public enum QuestType { Collect,Talk,Reach};
    public enum QuestStatus { Waiting,Accepted,Completed};
    
    public string questname;
    public QuestType questType;
    public QuestStatus questStatus;

    public string Description { get; set; }
    public bool Completed { get; set; }
    public int CurrentAmount { get; set; }

    [Header("Gathering Type Quest")]
    public int RequiredAmount;
    public object questData { get; internal set; }



    public virtual void Init()
    {
        //defult init stuff
    }
    //public void Evaluate()
    //{
    //    if (CurrentAmount >= RequiredAmount)
    //    {
    //        Complete();
    //    }
    //}

    //public void Complete()
    //{
    //    Quest.CheckGoals();
    //    Completed = true;
    //}

}
