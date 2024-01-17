using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PasswordScript : MonoBehaviour
{
    private string input;
    public GameObject winScreen;
    public ParticleSystem confetti;

    AudioSource audioSource;

    public AudioClip winSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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

        if (input == "                                                  ") //the password is just a bunch of spaces, this was always the plan but idk how to script counting characters
        {
            Debug.Log ("You Win!");
            winScreen.SetActive(true);
            Instantiate(confetti);
            PlaySound(winSound);
        }
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
