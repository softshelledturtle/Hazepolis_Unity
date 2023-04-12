using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestNameButton : MonoBehaviour
{
    public Text questNameText;
    public Text questBtnName;
    public QuestData_SO currentData;
    public Text questContentText;
    public Text questRequirement;
    public Text questReward;

    public void SetupNameButton(QuestData_SO quesData)
    {
        currentData = quesData;

        if (quesData.isComplete)
            questNameText.text = quesData.questName + "(完成)";
        else
            questNameText.text = quesData.questName;
    }

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(UpdateQuestContent);
    }
    void UpdateQuestContent()
    {
        questContentText.text = currentData.description;
        questNameText.text = currentData.questName;
        questBtnName.text = currentData.questBtnName;
        questReward.text = currentData.reward;
        questRequirement.text = currentData.require;
        //QuestUI.Instance.SetupRequireList(currentData);

        //foreach (Transform item in QuestUI.Instance.rewardTransform)
        //{
        //    Destroy(item.gameObject);
        //}


        //foreach (var item in currentData.rewards)//獎勵可能不止一個所以需要循環列表
        //{
        //    QuestUI.Instance.SetupRewardItem(item.itemData, item.amount);
        //}
    }
}