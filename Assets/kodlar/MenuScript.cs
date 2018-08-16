using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public GameObject highScore;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void PlayOnlineGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    void Start()
    {
        int Score = PlayerPrefs.GetInt("highScore", 0);
        highScore.GetComponent<TextMeshProUGUI>().text = "high score  " + Score.ToString();
    }
}
