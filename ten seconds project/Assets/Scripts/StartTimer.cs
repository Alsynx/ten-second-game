using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; //MUST include this if any TMP elements are to be included in the code, which happens to be the input field in this case

public class StartTimer : MonoBehaviour
{

    public float timeLeft = 2.0f;

    public GameObject startScreen;
    public GameObject countdownScreen;
    public GameObject mashSpaceSprite;
    public TMP_InputField passwordBar;
    public AudioSource startSFX;

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            startScreen.SetActive(false); //for w/e reason this causes error messages in the unity console but doesn't do anything. disabling it in a way breaks it, but that's what i want so...?
            countdownScreen.SetActive(true);
            startSFX.Stop();
        }

        if (startScreen.activeInHierarchy == false)
        {
            passwordBar.Select();
            mashSpaceSprite.SetActive(true);
        }
    }
} 
