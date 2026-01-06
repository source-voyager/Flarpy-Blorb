using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovementScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = -30;
    public LogicScript logic;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        //moves the pipe to the left
        transform.position += (new Vector3(-1, 0, 0) * moveSpeed) * Time.deltaTime;

        switch (logic.stage) {
            case 0:
                moveSpeed = 5;
                break;
            case 1:
                moveSpeed = 5.5F;
                break;
            case 2:
                moveSpeed = 6;
                break;
            case 3:
                moveSpeed = 7;
                break;
            case 4:
                moveSpeed = 7.5F;
                break;
            case 5:
                moveSpeed = 8;
                break;
            case 6:
                moveSpeed = 10;
                break;
            case 7:
                moveSpeed = 10.3F;
                break;
        }

        //destroys the pipe if it exceeds the screen's limit
        if (transform.position.x < deadZone) {
            Destroy(gameObject);
        }
    }
}
