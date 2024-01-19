using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{

    public float timeLeft = 12.0f;
    public Text startText; // used for showing countdown from 3, 2, 1 

    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject countdownScreen;

    AudioSource audioSource;
    public GameObject loseSound; //somehow identifying it as an audio clip or source turns it into a megaphone, so it has to be a game object for w/e reason
    public AudioSource bgMusic;

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); //somehow i always forget, but in order for this to work you need to attach an audio source component to the main camera
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        startText.text = (timeLeft).ToString("0");
        if (timeLeft < 0)
        {
            if (winScreen.activeInHierarchy != true)
            {
                loseScreen.SetActive(true);
                loseSound.SetActive(true);
                countdownScreen.SetActive(false);
            }

            countdownScreen.SetActive(false);

            if (loseScreen.activeInHierarchy == true)
            {
                bgMusic.Stop(); //i meant to also have the music stop on win, but i couldn't figure out it out no matter how i wrote it
            }
        }
    }
    
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
} 
