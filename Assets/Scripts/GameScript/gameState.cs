using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameState : MonoBehaviour
{
    bool gameOver = false;
    public void gameOverScreen()
    {
        if (!gameOver){
            menuSwapper swapper = new menuSwapper();
            
            gameOver = true;
        }
    }
}
