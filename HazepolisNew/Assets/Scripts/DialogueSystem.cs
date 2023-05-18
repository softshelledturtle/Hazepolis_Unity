using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem Instance;

    public GameObject dialoguePanel;
    public string npcName;
    public List<string> dialogueLines = new List<string>();

    Button continueButton;
    Text dialogueText, nameText;
    int dialogueIndex;

    public QuestGiver currentQuestgiver;
    public QuestTarget questTarget;
    public TalkButton talkButton;

    void Awake()
    {
        continueButton = dialoguePanel.transform.Find("Continue").GetComponent<Button>();
        dialogueText = dialoguePanel.transform.Find("Text").GetComponent<Text>();
        nameText = dialoguePanel.transform.Find("Name").GetChild(0).GetComponent<Text>();
        continueButton.onClick.AddListener(delegate { ContinueDialogue(); });
        dialoguePanel.SetActive(false);

        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }


    }

    public void AddNewDialogue(string[] lines, string npcName)
    {
        dialogueIndex = 0;
        dialogueLines = new List<string>(lines.Length);
        dialogueLines.AddRange(lines);
        this.npcName = npcName;

        CreatDialogue();
    }

    public void CreatDialogue()
    {
        dialogueText.text = dialogueLines[dialogueIndex];
        nameText.text = npcName;
        dialoguePanel.SetActive(true);
    }

    public void ContinueDialogue()
    {
        
        if (dialogueIndex < dialogueLines.Count-1)
        {
            dialogueIndex++;
            dialogueText.text = dialogueLines[dialogueIndex];
        }
        else
        {
            Debug.Log("AAAAAAAAAAAAAAAAAAA");
            
            CheckQuestIsComplete();
            print(CheckQuestIsComplete());

            if (CheckQuestIsComplete() && currentQuestgiver.isFinished == false)
            {
                AddNewDialogue(talkButton.congratslines, npcName);
                currentQuestgiver.isFinished = true;
            }
            else
            {
                dialoguePanel.SetActive(false);

                if (currentQuestgiver == null)
                {
                    Debug.Log("There is no quest in this person");
                }
                else
                {
                    currentQuestgiver.GiveQuest();


                    if (CheckQuestIsComplete() && currentQuestgiver.isFinished == false)
                    {
                        AddNewDialogue(talkButton.congratslines, talkButton.npcName);
                        currentQuestgiver.isFinished = true;
                    }
                }
                if (questTarget != null)
                {
                    for (int i = 0; i < Quest.instance.Goals.Count; i++)
                    {
                        if (Quest.instance.Goals[i].questname == questTarget.questName)
                        {   questTarget.hasTalked = true;
                            questTarget.QuestComplete();
                        }
                    }       
                }
                else { return; }
            }

            #region//backup
            //if (currentQuestgiver == null)
            //{ 
            //    Debug.Log("There is no quest in this person"); 
            //}
            //else 
            //{ 
            //    currentQuestgiver.GiveQuest();
            //    QuestManager.instance.UpdateGoals();
            //}
            //if (questTarget != null)
            //{
            //    questTarget.hasTalked = true;
            //    questTarget.QuestComplete();
                
            //}
            //else { return; }
            #endregion
        }
    }

    //public bool GetQuestResult()
    //{
    //    //if (talkable.questable == null)
    //    //    return false;

    //    //for (int i = 0; i < Player.instance.questList.Count; i++)
    //    //{
    //    //    if (talkable.questable.quest.questName == Player.instance.questList[i].questName
    //    //        && Player.instance.questList[i].questStatus == Quest.QuestStatus.Completed)
    //    //    {
    //    //        talkable.questable.quest.questStatus = Quest.QuestStatus.Completed;
    //    //        return true;
    //    //    }
    //    //}

    //    //return false;
    //}

    // 檢查任務是否已經完成，如果完成的話回傳值為True
    public bool CheckQuestIsComplete() {
        if (currentQuestgiver == null) 
        {
            return false;
        }

        for (int i = 0; i < Quest.instance.Goals.Count; i++)
        {
            if (currentQuestgiver.goal.questname == Quest.instance.Goals[i].questname
                && Quest.instance.Goals[i].questStatus == Goal.QuestStatus.Completed)
            {
                currentQuestgiver.goal.questStatus = Goal.QuestStatus.Completed;
                return true;
            }
        }
        return false;
    }

}
