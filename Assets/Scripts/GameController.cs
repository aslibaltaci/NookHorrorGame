using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int correctL;
    public int correctM;
    public int correctR;

    public ReadNote noteL;
    public ReadNote noteM;
    public ReadNote noteR;

    public LockInteraction lockMenu;

    public float timer;

    public bool gameIsOver = false;
    public bool gameIsOverLost = false;

    public int health;

    public GameObject gameOverUI;
    public GameObject gameWinUI;

    public GameObject Pausing;
    public GameObject LockMenu;
    public GameObject Enemy;

    // Start is called before the first frame update
    void Start()
    {
        correctL = Random.Range(0, 9);
        correctM = Random.Range(0, 9);
        correctR = Random.Range(0, 9);
    }

    // Update is called once per frame
    void Update()
    {
        noteL.LockNumber = correctL;
        noteM.LockNumber = correctM;
        noteR.LockNumber = correctR;

        if (!gameIsOver)
        {
            timer += Time.deltaTime;
        }

        if (int.Parse(lockMenu.NumTXT.text) == correctL &&
            int.Parse(lockMenu.NumTXTM.text) == correctM &&
            int.Parse(lockMenu.NumTXTR.text) == correctR)
        {
            gameIsOver = true;
        }

        if (health <= 0)
        {
            gameIsOverLost = true;
        }

        if(gameIsOverLost)
        {
            gameOverUI.SetActive(true);
            if (Input.GetButtonDown("MenuButton"))
            {
                SceneManager.LoadScene(0);
            }
        }

        if(gameIsOver)
        {
            gameWinUI.SetActive(true);

            Pausing.GetComponent<PauseMenu>().enabled = false;
            LockMenu.GetComponent<LockInteraction>().enabled = false;
            Enemy.GetComponent<EnemyController>().enabled = false;

            if (Input.GetButtonDown("MenuButton"))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
