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
        if(dialogueIndex < dialogueLines.Count-1)
        {
            dialogueIndex++;
            dialogueText.text = dialogueLines[dialogueIndex];
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
                QuestManager.instance.UpdateGoals();
                //©I¥s¼uµ¡
            
            }
            if (questTarget != null)
            {
                questTarget.hasTalked = true;
                questTarget.QuestComplete();
            }
            else { return; }

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

}
