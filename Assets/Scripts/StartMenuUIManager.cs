using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class StartMenuUIManager : MonoBehaviour
{
    public string PlayerName ="Nameless One";
    public Text PlayerInput;

    private void Start()
    {

    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void StartClicked()
    {
        if (PlayerInput.text != null)
        {
            PlayerName = PlayerInput.text;
        }

        
        InfoManager.Instance.PlayerName = PlayerName;
        // NewName(PlayerName);
        StartNew();
    }

    public void Exit()
    {
        //MainManager.Instance.SaveHighscore();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
