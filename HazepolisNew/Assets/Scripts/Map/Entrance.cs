using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance : MonoBehaviour
{
    public string entrancePassword;

    private void Start()
    {
        if(Eammon.instance.scenePassWord == entrancePassword)
        {
            Eammon.instance.transform.position = transform.position;
            if (!Eammon.instance.foundDan)
            {
                Dan.instance.transform.position = new Vector3(0, 20, 0);
            }
            else
            {
                Dan.instance.transform.position = transform.position;
            }
            Debug.Log("ENTER");
        }
        else
        {
            Debug.Log("WRONGENTER");
        }
    }
}
