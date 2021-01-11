using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int highScore = PlayerPrefs.GetInt("Highscore");
        int recentScore = Player.RecentScore;

        if (gameObject.name == "Score Text")
        {
            gameObject.GetComponent<Text>().text = recentScore.ToString(); 
        }
        else if (gameObject.name == "HighScore Text")
        {
            gameObject.GetComponent<Text>().text = highScore.ToString();
        }
    }
}
