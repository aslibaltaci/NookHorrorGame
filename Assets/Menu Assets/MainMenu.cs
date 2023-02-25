using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject Play;
    public GameObject Quit;

    public Sprite PlaySelected;
    public Sprite QuitSelected;

    public Sprite PlayUnSelected;
    public Sprite QuitUnSelected;

    private bool IsPlayHover = true;
    private bool IsQuitHover = false;

    private bool MenuChanged = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetAxis("LockValue") == 0)
        {
            MenuChanged = false;
        }

        if (IsPlayHover)
        {
            Play.GetComponent<Image>().sprite = PlaySelected;

            PlayGame();
        }
        else if (IsQuitHover)
        {
            Quit.GetComponent<Image>().sprite = QuitSelected;

            QuitGame();
        }
    }

    void PlayGame()
    {
        if (Input.GetButtonDown("MenuButton"))
        {
            SceneManager.LoadScene(1);
        }

        else if (Input.GetAxis("LockValue") < 0 && !MenuChanged)
        {
            MenuChanged = true;

            IsPlayHover = false;
            IsQuitHover = true;

            Play.GetComponent<Image>().sprite = PlayUnSelected;
        }
    }

    void QuitGame()
    {
        if (Input.GetButtonDown("MenuButton"))
        {
            Application.Quit();
        }
        else if (Input.GetAxis("LockValue") > 0 && !MenuChanged)
        {
            MenuChanged = true;

            IsPlayHover = true;
            IsQuitHover = false;

            Quit.GetComponent<Image>().sprite = QuitUnSelected;
        }
    }
}