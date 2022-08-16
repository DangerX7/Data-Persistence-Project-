using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    private GameManager Manager;
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText, HighScoreText;
    public GameObject GameOverText;
    
    private bool m_Started = false;
    private int m_Points;
    
    private bool m_GameOver = false;

    
    // Start is called before the first frame update
    void Start()
    {
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
        if (GameObject.Find("Game Manager") != null)
        {
            Manager = GameObject.Find("Game Manager").GetComponent<GameManager>();

            HighScoreText.text = "Best Score : " + Manager.playerRecordName + " " + Manager.highScore;
        }
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";
    }

    public void GameOver()
    {
        if (m_Points > Manager.highScore5 && m_Points < Manager.highScore4)
        {
            Manager.highScore5 = m_Points;
            Manager.playerRecordName5 = Manager.playerName;
        }
        else if (m_Points > Manager.highScore4 && m_Points < Manager.highScore3)
        {
            Manager.highScore5 = Manager.highScore4;
            Manager.playerRecordName5 = Manager.playerRecordName4;

            Manager.highScore4 = m_Points;
            Manager.playerRecordName4 = Manager.playerName;
        }
        else if (m_Points > Manager.highScore3 && m_Points < Manager.highScore2)
        {
            Manager.highScore5 = Manager.highScore4;
            Manager.playerRecordName5 = Manager.playerRecordName4;
            Manager.highScore4 = Manager.highScore3;
            Manager.playerRecordName4 = Manager.playerRecordName3;

            Manager.highScore3 = m_Points;
            Manager.playerRecordName3 = Manager.playerName;
        }
        else if (m_Points > Manager.highScore2 && m_Points < Manager.highScore)
        {
            Manager.highScore5 = Manager.highScore4;
            Manager.playerRecordName5 = Manager.playerRecordName4;
            Manager.highScore4 = Manager.highScore3;
            Manager.playerRecordName4 = Manager.playerRecordName3;
            Manager.highScore3 = Manager.highScore2;
            Manager.playerRecordName3 = Manager.playerRecordName2;

            Manager.highScore2 = m_Points;
            Manager.playerRecordName2 = Manager.playerName;
        }
        else if (m_Points > Manager.highScore)
        {
            Manager.highScore5 = Manager.highScore4;
            Manager.playerRecordName5 = Manager.playerRecordName4;
            Manager.highScore4 = Manager.highScore3;
            Manager.playerRecordName4 = Manager.playerRecordName3;
            Manager.highScore3 = Manager.highScore2;
            Manager.playerRecordName3 = Manager.playerRecordName2;
            Manager.highScore2 = Manager.highScore;
            Manager.playerRecordName2 = Manager.playerRecordName;

            Manager.highScore = m_Points;
            Manager.playerRecordName = Manager.playerName;
        }
        Manager.SaveScore();
        Debug.Log("highscore " + Manager.highScore);
      //  Debug.Log("points " + m_Points);
        m_GameOver = true;
        GameOverText.SetActive(true);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(1);
    }
}
