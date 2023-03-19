using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnEvent : MonoBehaviour
{
    //public GameObject btnObj;
    //public GameObject BagMenu;
    //public GameObject Open;
    //public GameObject Back;
    //Button btn;
    //bool showed = false;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    BagMenu.SetActive(showed);
    //    btn.onClick.AddListener(delegate()
    //        {
    //            showed = !showed;
    //            BagMenu.SetActive(showed);
    //            if (showed)
    //            {
    //                btn.GetComponent<GameObject>().panel = Open;
    //            }
    //        }
    //    )
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    public void ActiveGob(GameObject gameObject)
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
