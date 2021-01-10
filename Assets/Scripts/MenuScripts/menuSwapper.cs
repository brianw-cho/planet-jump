using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    private readonly int inGameIndex = 1;
    private readonly int inMenuIndex = 0;
    private readonly int inEndIndex = 2;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startGame()
    {
        SceneManager.LoadScene(inGameIndex);
    }


}
