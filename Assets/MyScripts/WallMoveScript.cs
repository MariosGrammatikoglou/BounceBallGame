using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class WallMoveScript : MonoBehaviour
{
    public int moveSpeed;
    public float deadZone = -30.5f;
    public LogicScript scoreArea;
    


    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 10;
        scoreArea = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if(transform.position.x < deadZone)
        {
            
            Destroy(gameObject);
        }
        if(scoreArea.playerScore > 9 && scoreArea.playerScore < 20)
        {
            moveSpeed = 12;
        }
        if (scoreArea.playerScore > 19)
        {           
            moveSpeed = 14;
        }
    }
}
