using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager Instance;

    public string playerName;
    public int score;
    public string highScoreName;
    public int highScore;

    private void Awake() {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }

    [System.Serializable]
    public class SaveData {
        public string name;
        public int score;
    }

    public void SaveScore() {
        if (score <= highScore) {
            //don't update high score if new score is the same or lower
            return;
        }
        //update active highscore
        highScore = score;
        highScoreName = playerName;

        //save new high score
        SaveData data = new SaveData();
        data.name = highScoreName;
        data.score = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/highscore.json", json);
    }

    public void LoadScore() {
        string path = Application.persistentDataPath + "/highscore.json";
        if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScoreName = data.name;
            highScore = data.score;
        }
    }
}
