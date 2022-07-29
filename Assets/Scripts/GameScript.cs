using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    //=========== GUI Elements 
    public TextMeshProUGUI score;   //Tells us the score of the player 
    public TextMeshProUGUI lives;   //Tells us how many lives the player has 

    private int scoreCounter = 0;   //Keeps Track of the score 
    private int livesCounter = 3;   //Keeps Track of the lives left 

    //========== Ball Controls 
    public GameObject ball;
    public Transform spawnPoint;

    //========== Spike Controls 
    public List<Transform> points;  //Holds all of the points that the spike goes through 
    public float speed = 5;         //The Speed of the spikes movement 
    private int index = 0;          //Which index that spike is moving towards 

    //========== Level Controls 
    public string levelName;

    //===============================================================
    //Base Functions
    //===============================================================

    //Preset the texts 
    private void Start()
    {
        score.SetText("Score: 0");
        //Present the Text to values of 0
    }

    // Update is called once per frame
    void Update()
    {
        //Tells it to move from currently standing in point, to given point at the given speed 
        transform.position = Vector3.MoveTowards(transform.position, points[index].position,
                    speed * Time.deltaTime);
        //Rotate to the direction 
        transform.rotation = points[index].rotation;
        //Checks if the enemy reached their goal 
        if (transform.position == points[index].position)
        {
            //If it's the last spot reset 
            if (index == points.Count - 1)
            {
                index = 0;
            }
            //else just go to next point in the list 
            else
            {
                index++;
            }
        }
    }

    //===============================================================
    //Extra Functions 
    //===============================================================

    //Lowers the counter of lives, and updates the text 
    public void SpikeUpdate()
    {
        livesCounter--;
        //Update the text 
        lives.SetText("lives: " + livesCounter);
        if (livesCounter == 0)
        {
            BackToMainMenu();
        }
        
    }

    //Increase the score and updates the text 
    public void GoalUpdate()
    {
        scoreCounter++;
        score.SetText("score: " + scoreCounter);
        //Update the Text 
    }

    //Creates a new ball
    public void SpawnBall()
    {
        //Create Ball
        Instantiate(ball, spawnPoint.position, Quaternion.identity);
    }

    //Sends the game back to the main menu scene 
    private void BackToMainMenu()
    {
        SceneManager.LoadScene("MenuScene");
        //Send back to the main menu
    }
}
