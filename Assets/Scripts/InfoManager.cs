using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InfoManager : MonoBehaviour
{
    public static InfoManager Instance;
    public string PlayerName;
    public string HighscoreName;
    public int Highscore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighscore();
    }

    public void UpdateHighscore(int score)
    {
        Highscore = score;
        HighscoreName = PlayerName;
    }

    [System.Serializable]
    class SaveData
    {
        public string HighscoreName;
        public int Highscore;
    }

    public void SaveHighscore()
    {
        SaveData data = new SaveData();
        data.HighscoreName = HighscoreName;
        data.Highscore = Highscore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighscore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighscoreName = data.HighscoreName;
            Highscore = data.Highscore;
        }
    }
}
