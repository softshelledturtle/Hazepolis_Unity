using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestNameButton : MonoBehaviour
{
    //public static QuestNameButton instance; 

    public Quest currentData;

    public Text questNameText;
    public Text questContentText;
    public Text questRequirement;
    public Text questReward;


    private void Awake()
    {
        Quest.instance = currentData;
        GetComponent<Button>().onClick.AddListener(UpdateQuestContent);
        //if (instance == null) { instance = this; }
        //else
        //{
        //    if (instance != this)
        //    {
        //        Destroy(gameObject);
        //    }
        //}
        //DontDestroyOnLoad(transform.root.gameObject);
    }
    void UpdateQuestContent()
    {
        
        questContentText.text = currentData.Description;
        questNameText.text = currentData.QuestName;
        
        questReward.text = currentData.QuestReward;
        questRequirement.text = currentData.QuestRequire;


        //QuestUI.Instance.SetupRequireList(currentData);

        //foreach (Transform item in QuestUI.Instance.rewardTransform)
        //{
        //    Destroy(item.gameObject);
        //}


        //foreach (var item in currentData.rewards)//���y�i�ण��@�өҥH�ݭn�`���C��
        //{
        //    QuestUI.Instance.SetupRewardItem(item.itemData, item.amount);
        //}
    }


}