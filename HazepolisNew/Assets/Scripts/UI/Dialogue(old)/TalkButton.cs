using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TalkButton : MonoBehaviour
{
    public GameObject Button;
    public GameObject DialogUI;

    public QuestGiver questgiver;
    public QuestTarget questTarget;
    public TalkButton talkButton;
    public string npcName;


    [TextArea(1, 5)] 
    public string[] lines;
    [TextArea(1, 4)]
    public string[] congratslines;
    [TextArea(1, 4)]
    public string[] completelines;

    //靠近NpC顯示對話符號
    private void OnTriggerEnter2D(Collider2D other)
    {
        Button.SetActive(true);//DialogUI.SetActive(true);
        DialogueSystem.Instance.currentQuestgiver = questgiver;
        DialogueSystem.Instance.questTarget = questTarget;
        DialogueSystem.Instance.talkButton = this;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Button.SetActive(false);//DialogUI.SetActive(false);

        DialogueSystem.Instance.currentQuestgiver = null;

    }

    void Update()
    {
        if (Button.activeSelf && Input.GetKeyDown(KeyCode.T))
        {
            if (questgiver == null)
            {
                DialogUI.SetActive(true);
                //trigger.StartDialog();
                DialogueSystem.Instance.AddNewDialogue(lines, npcName);
                Debug.Log("Conversation");
                if (this.tag == "Interactable")
                {
                this.GetComponent<Interactable>().Interact();
                }
            }
            else
            {
                if (questgiver.goal.questStatus == Goal.QuestStatus.Completed)
                {
                    DialogueSystem.Instance.AddNewDialogue(completelines, npcName);
                }
                else
                {
                    DialogueSystem.Instance.AddNewDialogue(lines, npcName);
                }
            }

        }
    }
}
