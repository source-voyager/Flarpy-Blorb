using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSCript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool alive = true;

    void Start() {
        //saves the logic's script logic game object that's in scene on the variable "logic"
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update() {

        //jumps every time the space key is pressed and the player is alive (legacy input) (will change that later)
        if (Input.GetKeyDown(KeyCode.Space) && alive) {
            myRigidbody.linearVelocity = new Vector2(0, flapStrength);

        }

        //kills the player if  it goes out of border
        if(transform.position.y <= -13.5 || transform.position.y >= 13.5) {
            kill();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        //kills the player if it collides with something
        kill();
    }

    private void kill() {
        logic.gameOver();
        alive = false;
    }
}