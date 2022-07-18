using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static bool GameIsPaused;

    public void ShowPauseMenu()
    {
        this.gameObject.SetActive(true);
        Time.timeScale = 0F;
    }

    public void ContinueGame()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1F;
    }

    public void RestartGame()
    {
        Time.timeScale = 1F;
        PlayerPrefs.SetInt("Level", 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ToMenu()
    {
        Time.timeScale = 1F;
        PlayerPrefs.SetInt("Level", 1);
        SceneManager.LoadScene(0);
    }
    
}
