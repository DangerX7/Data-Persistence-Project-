using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using TMPro;

public class MenuManager : MonoBehaviour
{
    private GameManager Manager;
    public TMP_InputField NameInput;
    public TextMeshProUGUI placeholder, nameInput;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("Game Manager") != null)
        {
            Manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InsertPlayerName()
    {
        placeholder.text = " ";
        Manager.playerName = NameInput.text;
    }

    public void GoToMainScene()
    {
        Debug.Log(Manager.playerName + placeholder.text);
        SceneManager.LoadScene(0);
    }

    public void GoToScoresScene()
    {
        SceneManager.LoadScene(2);
    }

    public void ExitApplication()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
