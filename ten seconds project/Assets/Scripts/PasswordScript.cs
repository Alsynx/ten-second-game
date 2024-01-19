using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PasswordScript : MonoBehaviour
{
    private string input;
    public GameObject winScreen;
    public GameObject loseScreen;
    public ParticleSystem confetti;

    AudioSource audioSource;

    public AudioClip winSound;
    public AudioClip loseSound;
    public AudioClip inputSFX;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); //somehow i always forget, but in order for this to work you need to attach an audio source component to the main camera
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
           restartScene();
        }
    }

    public void ReadStringInput(string Password)
    {
        input = Password;
        Debug.Log(input);

        if (input == "                                                                                ") //the password is just a bunch of spaces, this was always the plan but idk how to script counting characters
        {
            Debug.Log ("You Win!");
            winScreen.SetActive(true);
            Instantiate(confetti);
            PlaySound(winSound);
            //GameTimer.SetActive(false);
        }

        PlaySound(inputSFX);
    }

    public void restartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
