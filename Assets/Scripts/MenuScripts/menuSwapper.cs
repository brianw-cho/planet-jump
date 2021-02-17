using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuSwapper : MonoBehaviour
{
    // Start is called before the first frame update
    private readonly int inGameIndex = 1;
    private readonly int inMenuIndex = 0;
    private readonly int inEndIndex = 2;
    public GameObject pauseMenu;

    public void startGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(inGameIndex);
    }

    public void endScreen()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(inEndIndex);
    }

    public void menuScreen(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(inMenuIndex);
    }

    



    public void pause(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void resume(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

}
