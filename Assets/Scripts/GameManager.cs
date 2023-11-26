using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform playerPaddle;
    public Transform enemyPaddle;
    public BallController ballController;

    public int playerScore = 0;
    public int enemyScore = 0;

    public TextMeshProUGUI textPlayerPoints;
    public TextMeshProUGUI textEnemyPoints;

    public int winPoints = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        ResetGame();
    }

    public void checkWin()
    {
        if (enemyScore >= winPoints || playerScore >= winPoints) 
        {
            ResetGame();
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
