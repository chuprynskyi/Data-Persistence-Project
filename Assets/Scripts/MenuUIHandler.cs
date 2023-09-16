using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI bestScore;
    public TMP_InputField playerName;

    private void Start()
    {
        bestScore.text = $"Best Score: {MenuManager.Instance.currPlayerName} : {MenuManager.Instance.bestScore}";
        playerName.text = MenuManager.Instance.currPlayerName;
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
            Application.Quit(); // original code to quit Unity player
#endif

    }

    public void ReadStringInput(string s)
    {
        MenuManager.Instance.newPlayerName = s;
        Debug.Log(s);
    }
}
