using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    
    public GameObject pausemenu,txtgerisayim;
    public bool isPaused;
    void Start()
    {
        isPaused = false;
    }


    void Update()
    {

    }
    public void BacktoMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void PauseGame()
    {
        if (!txtgerisayim.GetComponent<TextMeshProUGUI>().enabled)
        {
            if (!isPaused)
            {
                pausemenu.SetActive(true);
                Time.timeScale = 0f;
                isPaused = true;
            }
        }
    }
    public void ResumeGame()
    {
            pausemenu.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
