using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic;
    void Start()
    {
        //saves the logic's script logic game object that's in scene on the variable "logic"
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        //gives the score to the player if he's alive (the "magic number" 3 is the layer number that the player's in)
        if (collision.gameObject.layer == 3 && logic.playerAlive) {
            logic.addScore(1);
        }
    }
}
