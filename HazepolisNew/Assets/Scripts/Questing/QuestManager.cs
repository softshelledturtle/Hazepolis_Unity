using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;

    public GameObject[] questUIArray;
    public GameObject[] questNameBtn;
    public Quest Btn;
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
    //更新UI
    public void UpdateGoals()
    {
        for (int i = 0; i < Quest.instance.Goals.Count; i++)//有多少个任务显示多少个List，而不是有多少List显示多少个任务
        {
            questUIArray[i].transform.GetChild(1).GetComponent<Text>().text = Quest.instance.Goals[i].questname;
            //questNameBtn.transform.GetComponent<Button>().interactable = true;
            questUIArray[i].SetActive (true);
            //Btn = questNameBtn.GetComponent<QuestNameButton>().currentData;

            if (Quest.instance.Goals[i].questStatus == Goal.QuestStatus.Accepted)
            {
                questUIArray[i].transform.GetChild(0).GetComponent<Text>().text
                = "<color=red>" + Quest.instance.Goals[i].questStatus + "</color>";
            }
            else if (Quest.instance.Goals[i].questStatus == Goal.QuestStatus.Completed)
            {
                questUIArray[i].transform.GetChild(0).GetComponent<Text>().text
                = "<color=lime>" + Quest.instance.Goals[i].questStatus + "</color>";
            }
        }
    }

}
