using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddleController : MonoBehaviour
{
    public float speed = 5f;
    public EnemyPaddleController enemyPaddle;
    public bool isPlayer = true;
    public bool isEnemy = true;
    public SpriteRenderer spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        if (isPlayer)
        {
            spriteRenderer.color = SaveController.Instance.colorPlayer;
        }
        else
        {
            spriteRenderer.color = SaveController.Instance.colorEnemy;
        }
    }

    // Update is called once per frame
    void Update()
    {
   
        //vertical input detector
        float moveInput = Input.GetAxis("Vertical3");

        //new position
        Vector3 newPosition = transform.position + Vector3.up * moveInput * speed * Time.deltaTime;

        //block screen borders
        newPosition.y = Mathf.Clamp(newPosition.y, -4.5f, 4.5f);

        //update paddle position
        transform.position = newPosition;
    }
}
