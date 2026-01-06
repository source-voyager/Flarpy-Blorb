using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    //public Camera camera;
    public int playerScore;
    public int stage = 0;
    public Text scoreText;
    public GameObject gameOverScreen;
    public bool playerAlive = true;
    public AudioSource scoreSound;
    public AudioSource backgroundMusic;

    [ContextMenu("Increase Score")]
    public void addScore(int amount) {
        scoreSound.Play();
        playerScore += amount;
        scoreText.text = playerScore.ToString();
    }

    private void Start() {
        backgroundMusic.pitch = 1;
        backgroundMusic.Play();
    }
    private void Update() {

        //changes the color of the score text depending on the stage of the game
        switch (stage) {
            case 0:
                scoreText.color = HexToColor("#FFFFFF");
                break;
            case 1:
                scoreText.color = HexToColor("#00FFFF"); //cyan
                break;
            case 2:
                scoreText.color = HexToColor("#00FF00"); //green
                break;
            case 3:
                scoreText.color = HexToColor("#FFFF00"); //yellow
                break;
            case 4:
                scoreText.color = HexToColor("#0000FF"); //blue
                break;
            case 5:
                scoreText.color = HexToColor("#FF0000"); //red
                break;
            case 6:
                scoreText.color = HexToColor("#8826FA"); //purple
                break;
            case 7:
                scoreText.color = HexToColor("#000000"); //black
                break;
            default:
                break;
        }
    }

    private Color HexToColor(string hex) {
        //gets the hexadecimal color code and parses it as an html string returning the color code
        Color color;
        if (ColorUtility.TryParseHtmlString(hex, out color)) {
            return color;
        }
        return Color.white; //default fallback color
    }

    public void restartGame() {
        //reloads the current scene (might change later)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver() {
        backgroundMusic.pitch = 0.75F;
        playerAlive = false;
        gameOverScreen.SetActive(true);
    }
}

