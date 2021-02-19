using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private int score = 0;
    private static int mostRecentScore;
    Vector3 playerPosition { get; set; }
    public int fuel = 100;
    public int maxFuel = 100;
    public float fuelScale;
    public float speed = 0.01f;
    public bool onPlanet = false;
    private bool speedInc = false;
    static public Player s_Singleton;
    public FuelBar fuelBar;
    public Text scorePrinter;
    public ParticleSystem death;
    public ParticleSystem land;

    void Awake()
    {
        s_Singleton = this;
    }

    void Start()
    {
        playerPosition = transform.position;
        fuel = maxFuel;
    }

    // Update is called once per frame
    void Update()
    {
        fuelBar.SetFuel(fuel);
        if (fuel > maxFuel)
        {
            fuel = maxFuel;
        }

        if (score % 4 == 0 && score != 0 && !speedInc)
        {
            speed = speed * 1.5f;
            speedInc = true;
        }
        else if (score % 4 != 0 && speedInc)
        {
            speedInc = false;
        }
    }

    void FixedUpdate()
    {
        if (!onPlanet)
        {
            var pos = transform.position;
            transform.position = new Vector3(pos.x, pos.y - speed, pos.z);
        }

        if (Camera.main.WorldToScreenPoint(transform.position).x >= Screen.width ||
        Camera.main.WorldToScreenPoint(transform.position).x <= 0 ||
        Camera.main.WorldToScreenPoint(transform.position).y >= Screen.height ||
        Camera.main.WorldToScreenPoint(transform.position).y <= 0)
        {
            lose();
        }

        scorePrinter.text = score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D touchObj)
    {
        if (touchObj.gameObject.name == "Planet Child")
        {
            print(GetPlanetDirection(touchObj.gameObject));
        }
    }

    int playLose = 1;
    private void OnTriggerStay2D(Collider2D touchObj)
    {
        if (touchObj.gameObject.name.Contains("methorite"))
        {
            foreach (AudioSource aS in GameObject.FindObjectsOfType<AudioSource>())
            {
                if (aS.name == "Sound") aS.GetComponent<Audio>().playAudioClip(1, 1f);
            }
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Invoke("lose", 0.5f);
            if (playLose > 0)
            {
                Instantiate(death, transform.position, transform.rotation);
                playLose--;
            }
            transform.position = new Vector3(transform.position.x, transform.position.y, -111);
        }
    }
    public void DecreaseFuel(int amount)
    {
        foreach (AudioSource aS in GameObject.FindObjectsOfType<AudioSource>())
        {
            if (aS.name == "Sound") aS.GetComponent<Audio>().playAudioClip(2, 1f);
        }
        fuel = fuel - (int)(amount * fuelScale);
        fuelBar.SetFuel(fuel);
    }

    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    public static int RecentScore
    {
        get { return mostRecentScore; }
    }

    void lose()
    {
        foreach (AudioSource aS in GameObject.FindObjectsOfType<AudioSource>())
        {
            if (aS.name == "Sound") aS.GetComponent<Audio>().playAudioClip(3, 1f);
        }
        if (PlayerPrefs.GetInt("Highscore") < score)
        {
            PlayerPrefs.SetInt("Highscore", score);
        }
        mostRecentScore = score;
        FindObjectOfType<menuSwapper>().endScreen();

    }

    float GetPlanetDirection(GameObject planet)
    {
        Vector3 toPlanet = new Vector3(planet.transform.position.x - transform.position.x, planet.transform.position.y - transform.position.y, 0);
        float angle = Vector3.Angle(new Vector3(0.0f, 1.0f, 0.0f), toPlanet);
        if (toPlanet.x < 0.0f)
        {
            angle = 360f - angle;
        }
        return angle;
    }
}
