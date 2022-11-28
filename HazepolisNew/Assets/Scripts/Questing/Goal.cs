using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal 
{
    public string Description { get; set; }
    public bool Completed { get; set; }
    public int CurrenAmount { get; set; }
    public int RequiredAmount { get; set; }

    public virtual void Init()
    {
        //defult init stuff
    }
    public void Evaluate()
    {
        if (CurrenAmount >= RequiredAmount)
        {
            Complete();
        }
    }

    public void Complete()
    {
        Completed = true;
    }
}
