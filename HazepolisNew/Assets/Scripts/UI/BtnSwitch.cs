using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSwitch : MonoBehaviour
{
    public string scenePassWord;
    private bool foundDan = false;

    bool inputEnabled = true;
    public void Activate()
    {
        inputEnabled = true;
        if (scenePassWord == "Level0-1" && Input.GetKeyDown(KeyCode.F))
        {
            foundDan = true;
        }
        if (foundDan)
        {
            gameObject.GetComponent<FollowingPlayer>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<FollowingPlayer>().enabled = false;
        }
    }

    public void Deactivate()
    {
        inputEnabled = false;
        gameObject.GetComponent<FollowingPlayer>().enabled = false;
        gameObject.GetComponent<FollowingPlayer>().positionList.Clear();
    }
}
