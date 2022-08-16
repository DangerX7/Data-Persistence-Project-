using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreMenuScript : MonoBehaviour
{
    private GameManager Manager;
    public TextMeshProUGUI firstName, secondName, thirdName, fourthName, fifthName, firstScore, secondScore, thirdScore, fourthScore, fifthScore;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("Game Manager") != null)
        {
            Manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        }
        firstName.text = Manager.playerRecordName;
        secondName.text = Manager.playerRecordName2;
        thirdName.text = Manager.playerRecordName3;
        fourthName.text = Manager.playerRecordName4;
        fifthName.text = Manager.playerRecordName5;
        firstScore.text = Manager.highScore + "";
        secondScore.text = Manager.highScore2 + "";
        thirdScore.text = Manager.highScore3 + "";
        fourthScore.text = Manager.highScore4 + "";
        fifthScore.text = Manager.highScore5 + "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(1);
    }
}
