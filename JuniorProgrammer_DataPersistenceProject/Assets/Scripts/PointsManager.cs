using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    static public PointsManager instance;
    public string username;
    public string usernameBest;
    public int scoreBest;
    private string dirSave; 

    private void Awake()
    {
        dirSave = Application.persistentDataPath + "/highScore.json";

        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        LoadData();
    }

    [System.Serializable]
    class Data
    {
        public string username;
        public string usernameBest;
        public int scoreBest;

        public Data(string username, string usernameBest, int scoreBest)
        {
            this.username = username;
            this.usernameBest = usernameBest;
            this.scoreBest = scoreBest;
        }
    }

    public void ChangeBestScore(string username, int score)
    {
        this.usernameBest = username;
        this.scoreBest = score;
        SaveData();
    }

    public void SaveData()
    {
        Data data = new Data(username, usernameBest, scoreBest);
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(dirSave, json);
    }

    public void LoadData()
    {
        if (File.Exists(dirSave))
        {
            string json = File.ReadAllText(dirSave);
            Data data = JsonUtility.FromJson<Data>(json);
            username = data.username;
            usernameBest = data.usernameBest;
            scoreBest = data.scoreBest;
        }
    }
}
