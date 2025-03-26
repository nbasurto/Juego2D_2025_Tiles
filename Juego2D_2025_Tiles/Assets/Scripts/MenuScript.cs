using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

public class MenuScript : MonoBehaviour
{

    private void Start()
    {
        //Interactuar con el cursor de nuevo
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;      
    }
    public void ButtonPlay()
    {

        SceneManager.LoadScene(1);
    }

    public void ButtonEndGame()
    {
        Application.Quit();
    }


}
