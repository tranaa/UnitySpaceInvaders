using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isPlayerDead = false;
    public static bool isEnemyDead = false;
    public GameObject playAgainBtn;
    public Text gameOver;

    public Text winText;

    public static float playerScore = 0;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        gameOver.enabled = false;
        winText.enabled = false;
        playAgainBtn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + playerScore;

        if (isPlayerDead)
        {
            Time.timeScale = 0;
            gameOver.enabled = true;
            playAgainBtn.SetActive(true);
        }
        else if (isEnemyDead)
        {
            Time.timeScale = 0;
            winText.enabled = true;
            playAgainBtn.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayAgain();
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
        playerScore = 0;
        isPlayerDead = false;
        isEnemyDead = false;
        Time.timeScale = 1;
    }
}
