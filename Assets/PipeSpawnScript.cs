using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 6;
    private float timer = 0;
    public float heightOffset;
    public LogicScript logic;

    void Start()
    {
        //saves the logic's script logic game object that's in scene on the variable "logic"
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        
        //spawns a pipe at the start of the game
        spawnPipe();
    }

    void Update()
    {
        //increases the timer by 1 each second while the time is lower than the spawn rate
        if (timer < spawnRate) {
            timer += Time.deltaTime;
        }
        //once the timer is larger than the spawn rate, spawns a pipe and sets the timer to 0 so the loop starts again
        else {
            spawnPipe();
            timer = 0;
        }

        increaseDifficulty();

    }

    void spawnPipe() {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;


        /*
          instantiates a new pipe on the same X position as parent, 
          then the y position is a random number between the lowestPoint and highest point
         */
        if (logic.playerAlive) {
            Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
        }
    }

    void increaseDifficulty() {

        //feels wrong for me, might change later
        switch (logic.playerScore) {

            case 0:
                spawnRate = 5;
                heightOffset = 5;
                logic.stage = 0;
                break;
            case 3:
                spawnRate = 4.5F;
                logic.stage = 1;
                break;
            case 10: //12
                heightOffset = 6;
                logic.stage = 2;
                break;
            case 18: //20
                spawnRate = 3;
                logic.stage = 3;
                break;
            case 27: //30
                spawnRate = 2;
                heightOffset = 7.5F;
                logic.stage = 4;
                break;
            case 35: //40
                spawnRate = 1.5F;
                logic.stage = 5;
                break;
            case 45: //50
                spawnRate = 1.3F;
                logic.stage = 6;
                break;
            case 69:
                spawnRate = 1.25F;
                logic.stage = 7;
                break;

        }
    }
}
