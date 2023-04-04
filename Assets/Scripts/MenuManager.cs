using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour {

    public TextMeshProUGUI bestScore;
    public TMP_InputField nameInput;

    void Start () {
        bestScore.text = "Best Score : " + ScoreManager.Instance.highScoreName + " : " + ScoreManager.Instance.highScore;
        nameInput.text = ScoreManager.Instance.highScoreName;
    }

    public void StartGame() {
        ScoreManager.Instance.playerName = nameInput.text;
        SceneManager.LoadScene("main");
    }

    public void ExitGame() {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
