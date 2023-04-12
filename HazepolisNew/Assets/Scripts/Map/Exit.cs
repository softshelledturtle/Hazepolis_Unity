using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public string sceneName; //下一個場景
    [SerializeField]private string newScenePassword; //通關密語

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Eammon.instance.scenePassWord = newScenePassword;
            SceneManager.LoadScene(sceneName); 
        }
    }
}
