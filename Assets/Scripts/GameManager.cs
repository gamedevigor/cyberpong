using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform playerPaddle;
    public Transform enemyPaddle;
    public BallController ballController;
    public EnemyPaddleController player2;

    public int playerScore = 0;
    public int enemyScore = 0;

    public TextMeshProUGUI textPlayerPoints;
    public TextMeshProUGUI textEnemyPoints;

    public int winPoints = 5;

    public GameObject endScreen;
    public GameObject victoryScreen;
    public GameObject loseScreen;

    // Start is called before the first frame update
    void Start()
    {
        ResetGame();
    }

    public void checkWin()
    {
        if (enemyScore >= winPoints) 
        {
            endScreen.SetActive(true);
            loseScreen.SetActive(true);
            Invoke("LoadMenu", 2f);

        }

        else if (playerScore >= winPoints)
        {
            endScreen.SetActive(true);
            victoryScreen.SetActive(true);
            Invoke("LoadMenu", 2f);
        }
    }

    public void ResetGame()
    {
        //paddles initial position
        playerPaddle.position = new Vector3 (-7f, 0f , 0f);
        enemyPaddle.position = new Vector3 (7f, 0f , 0f);

        //reset ball position
        ballController.ResetBall();

        //score reset
        playerScore = 0;
        enemyScore = 0;

        textPlayerPoints.text = playerScore.ToString();
        textEnemyPoints.text = enemyScore.ToString();

        endScreen.SetActive(false);
        loseScreen.SetActive(false);
        victoryScreen.SetActive(false);

        player2.isPlayer = false;
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ScorePlayer()
    {
        playerScore++;
        textPlayerPoints.text = playerScore.ToString();
        checkWin();
    }

    public void ScoreEnemy()
    {
        enemyScore++;
        textEnemyPoints.text = enemyScore.ToString();
        checkWin();
    }
}
