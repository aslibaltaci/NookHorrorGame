using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused;

    public GameObject Resume;
    public GameObject Quit;

    public Sprite ResumeSelected;
    public Sprite QuitSelected;

    public Sprite ResumeUnSelected;
    public Sprite QuitUnSelected;

    private bool IsResumeHover = true;
    private bool IsQuitHover = false;

    private bool PauseOptionChanged = false;

    public GameObject StopMusic;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxis("LockValue") == 0)
        {
            PauseOptionChanged = false;
        }

        if (Input.GetButtonDown("PauseButton"))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                isPaused = true;
            }
        }

        if (isPaused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
            Cursor.lockState = CursorLockMode.Locked;

            StopMusic.GetComponent<AudioSource>().Pause();


            if (IsResumeHover)
            {
                Resume.GetComponent<Image>().sprite = ResumeSelected;
                Quit.GetComponent<Image>().sprite = QuitUnSelected;

                if (Input.GetAxis("LockValue") < 0 && !PauseOptionChanged)
                {
                    PauseOptionChanged = true;

                    IsResumeHover = false;
                    IsQuitHover = true;
                }
                else if (Input.GetButtonDown("MenuButton"))
                {
                    ResumeGame();
                }

            }

            if (IsQuitHover)
            {
                Resume.GetComponent<Image>().sprite = ResumeUnSelected;
                Quit.GetComponent<Image>().sprite = QuitSelected;

                if (Input.GetAxis("LockValue") > 0 && !PauseOptionChanged)
                {
                    PauseOptionChanged = true;

                    IsResumeHover = true;
                    IsQuitHover = false;
                }
                else if (Input.GetButtonDown("MenuButton"))
                {
                    ReturntoMenu();
                }
            }
        }
    }

    void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        StopMusic.GetComponent<AudioSource>().UnPause();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void ReturntoMenu()
    {
        ResumeGame();
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);

    }
}