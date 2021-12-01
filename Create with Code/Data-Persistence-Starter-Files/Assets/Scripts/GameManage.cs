using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class PlayData
{
    public string name;
    public int score;
}
public class GameManage : MonoBehaviour
{
    private static GameManage instance;

    public int scoreHighest;

    public string nameHighest;

    public string curName;
    // Start is called before the first frame update
    private void Awake()
    {
        // start of new code
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code
        
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
        LoadScore();
    }

    public static GameManage Instance => instance;

    public void SaveScore()
    {
        PlayData data = new PlayData();
        data.name = nameHighest;
        data.score = scoreHighest;

        string json = JsonUtility.ToJson(data);
  
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayData data = JsonUtility.FromJson<PlayData>(json);

            nameHighest = data.name;
            scoreHighest = data.score;
        }
    }
}
