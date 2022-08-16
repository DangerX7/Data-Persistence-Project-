using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public string playerName;
    public string playerRecordName, playerRecordName2, playerRecordName3, playerRecordName4, playerRecordName5;
    public int highScore, highScore2, highScore3, highScore4, highScore5;

    static GameManager Instance;

    public static GameManager GetGameManager()
    {
        return Instance;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string BestPlayerName, BestPlayerName2, BestPlayerName3, BestPlayerName4, BestPlayerName5;
        public int BestPlayerScore, BestPlayerScore2, BestPlayerScore3, BestPlayerScore4, BestPlayerScore5;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.BestPlayerName = playerRecordName;
        data.BestPlayerName2 = playerRecordName2;
        data.BestPlayerName3 = playerRecordName3;
        data.BestPlayerName4 = playerRecordName4;
        data.BestPlayerName5 = playerRecordName5;
        data.BestPlayerScore = highScore;
        data.BestPlayerScore2 = highScore2;
        data.BestPlayerScore3 = highScore3;
        data.BestPlayerScore4 = highScore4;
        data.BestPlayerScore5 = highScore5;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerRecordName = data.BestPlayerName;
            playerRecordName2 = data.BestPlayerName2;
            playerRecordName3 = data.BestPlayerName3;
            playerRecordName4 = data.BestPlayerName4;
            playerRecordName5 = data.BestPlayerName5;
            highScore = data.BestPlayerScore;
            highScore2 = data.BestPlayerScore2;
            highScore3 = data.BestPlayerScore3;
            highScore4 = data.BestPlayerScore4;
            highScore5 = data.BestPlayerScore5;
        }
    }
}
