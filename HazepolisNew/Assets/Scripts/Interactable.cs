using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private bool hasInteracted;

    public virtual void Interact()
    {
        Debug.Log("Interacting with base class.");
    }
}
