using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyPaddleController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;

    private GameObject ball;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ball = GameObject.Find("Ball"); //locate the ball
    }

    private void Update()
    {
        if (ball != null)
        {
            float targetY = Mathf.Clamp(ball.transform.position.y, -4.5f, 4.5f); //block screen borders
            Vector2 targetPosition = new Vector2(transform.position.x, targetY);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed); //follows the ball
        }
    }
}
