using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Audio : MonoBehaviour
{
    // Start is called before the first frame update7
    public Slider audioSlider;
    public AudioClip[] audioClips;
    private string sliderName;
    void Start()
    {
        if (gameObject.name == "Music")
        {
            sliderName = "Music Slider";
            GameObject[] audioSources = GameObject.FindGameObjectsWithTag("Music");
            if (audioSources.Length > 1) Destroy(gameObject);
            else DontDestroyOnLoad(gameObject);
        }
        else if (gameObject.name == "Sound")
        {
            sliderName = "Sound Slider";
            GameObject[] audioSources = GameObject.FindGameObjectsWithTag("Sound");
            if (audioSources.Length > 1) Destroy(gameObject);
            else DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Menu Screen")
        {
            if (audioSlider == null)
            {
                Slider[] sliders = Resources.FindObjectsOfTypeAll<Slider>();
                foreach (Slider s in sliders)
                {
                    if (s.name == sliderName) audioSlider = s;
                }
                audioSlider.value = gameObject.GetComponent<AudioSource>().volume;
            }
        gameObject.GetComponent<AudioSource>().volume = audioSlider.value;
        }
    }

    public void playAudioClip(int indNum, float volume)
    {
        if (sliderName == "Sound Slider")
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(audioClips[indNum], volume);
        }
    }
}
