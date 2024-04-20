using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float CircleStrength;
    public LogicScript logic;
    public bool ballIsAlive = true;
    private float yTopLevel = 11.3f;
    private float yBotLevel = -10.9f;
    public GameObject Animate;
    private float timer = 0;
    private float animateTime = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)==true && ballIsAlive)
        {
            myRigidbody.velocity = Vector2.up * CircleStrength;
            Animate.SetActive(true);
        }
        if(transform.position.y > yTopLevel || transform.position.y < yBotLevel)
        {
            logic.gameOver();
            ballIsAlive = false;
            Destroy(gameObject);
        }
        if (timer < animateTime)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Animate.SetActive(false);
            timer = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        ballIsAlive = false;
        Destroy(gameObject);
    }

    



}
