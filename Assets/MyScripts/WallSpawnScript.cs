using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawnScript : MonoBehaviour
{
    public GameObject wall;
    private float spawnRate;
    private float timer = 0;
    public float yRandomDistance = 7;
    public LogicScript scoreArea;



    // Start is called before the first frame update
    void Start()
    {
        spawnWall();
        spawnRate = 1.7f;
        scoreArea = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if(scoreArea.playerScore > 9)
        {
            spawnRate = 1.4f;
            Debug.Log("we did it, spawnrate :"+spawnRate);
        }
        if (scoreArea.playerScore > 19)
        {
            spawnRate = 1.3f;
            Debug.Log("we did it, spawnrate :" + spawnRate);
        }
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnWall();
            timer = 0;
        }
    }

    void spawnWall()
    {
        float lowestPoint = transform.position.y - yRandomDistance;
        float highestPoint = transform.position.y + yRandomDistance;

        Instantiate(wall, new Vector3(transform.position.x, Random.Range(lowestPoint,highestPoint),0), transform.rotation);
    }
}
