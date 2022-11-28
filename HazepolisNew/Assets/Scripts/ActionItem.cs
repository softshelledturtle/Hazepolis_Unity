using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionItem : Interactable
{
    // Start is called before the first frame update
    public override void Interact()
    {
        Debug.Log("Interacting with base ActionItem.");
    }
}
