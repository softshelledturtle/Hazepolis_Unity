using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal 
{
    public Quest Quest { get; set; }

    public string Description { get; set; }
    public bool Completed { get; set; }
    public int CurrentAmount { get; set; }
    public int RequiredAmount { get; set; }
    public object questData { get; internal set; }

    public virtual void Init()
    {
        //defult init stuff
    }
    public void Evaluate()
    {
        if (CurrentAmount >= RequiredAmount)
        {
            Complete();
        }
    }

    public void Complete()
    {
        Quest.CheckGoals();
        Completed = true;
    }

}
