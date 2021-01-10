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
    bool gameOver = false;

    public void startGame()
    {
        SceneManager.LoadScene(inGameIndex);
    }

    public void endScreen()
    {
        SceneManager.LoadScene(inEndIndex);
    }


}
