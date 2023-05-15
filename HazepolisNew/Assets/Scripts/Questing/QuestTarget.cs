using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//放在需要完成任務的對象上
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

    //任務完成後調用(物品集齊，指定人物對話)
    public void QuestComplete() {
        Debug.Log("UPDATE2222");
        for (int i = 0; i < Quest.instance.Goals.Count; i++)
        {
            Debug.Log("UPDATE77777");
            if (questName == Quest.instance.Goals[i].questname && Quest.instance.Goals[i].questStatus == Goal.QuestStatus.Accepted)
            {
                Debug.Log("UPDATE7888888");
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
