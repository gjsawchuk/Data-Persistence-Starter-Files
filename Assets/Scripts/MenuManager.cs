using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public string playerName;
    public TMP_InputField playerField;

    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.instance != null)
        {
            playerName = GameManager.instance.playerName;
        }
        playerField.text = playerName;

    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        GameManager.instance.Save();

        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }

    public void SetPlayerName()
    {
        GameManager.instance.playerName = playerField.text;
        Debug.Log(GameManager.instance.playerName);
    }
}
