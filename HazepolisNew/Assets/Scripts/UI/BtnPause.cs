using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnPause : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool IsShow;

    void Start()
    {

        pauseMenu.SetActive(false);
        IsShow = false;
        Time.timeScale = (1);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnPause();
        }
    }

    public void OnPause( )
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }
}
