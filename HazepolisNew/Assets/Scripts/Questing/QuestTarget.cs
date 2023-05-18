using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��b�ݭn�������Ȫ���H�W
public class QuestTarget : MonoBehaviour
{
    public string questName;
    public enum QuestType { Collect, Talk, Reach };
    public QuestType questType;

    [Header("Gathrting type quest")]
    public int amount = 0;

    [Header("Talk Type Quest")]
    public bool hasTalked;

    [Header("Reach Type Quest")]
    public bool hasReach;

    //���ȧ�����ե�(���~�����A���w�H�����)
    public void QuestComplete() {
        
        for (int i = 0; i < Quest.instance.Goals.Count; i++)
        {
           
            if (questName == Quest.instance.Goals[i].questname
                && Quest.instance.Goals[i].questStatus == Goal.QuestStatus.Accepted)
            {
              
                switch (questType)
                {
                    case QuestType.Collect:
                        if (Quest.instance.itemAmount >= Quest.instance.Goals[i].RequiredAmount)
                        {
                            Quest.instance.Goals[i].questStatus = Goal.QuestStatus.Completed;
                            QuestManager.instance.UpdateGoals();
                            Debug.Log("UPDATE");
                        }
                        break;
                    case QuestType.Talk:
                        if (hasTalked)
                        {
                            Quest.instance.Goals[i].questStatus = Goal.QuestStatus.Completed;
                            QuestManager.instance.UpdateGoals();
                        }
                        break; 
                    case QuestType.Reach:
                        if (hasReach)
                        {
                            Quest.instance.Goals[i].questStatus = Goal.QuestStatus.Completed;
                            QuestManager.instance.UpdateGoals();
                        }
                        break;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < Quest.instance.Goals.Count; i++) 
            {
                if (Quest.instance.Goals[i].questname == questName)
                {
                     if (questType == QuestType.Reach)
                    { 
                        hasReach = true;
                        QuestComplete();
                    }
                }
            }
        }

        //if (other.CompareTag("Player")) {

        //    if (questType == QuestType.Collect)
        //    {
        //        Quest.instance.itemAmount += amount;
        //        QuestComplete();
        //    } 
        //    else if(questType==QuestType.Reach)
        //    {
        //        hasReach = true;
        //        QuestComplete();
        //    }
        //}
    }
}
