//**************************************** GameController.cs *****************************************

//---------------calling the libraries---------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//---------------------------------------------------

public class GameController : MonoBehaviour
{
    public static GameController instance;

    //--------------------------------------------------variables------------------------------------------------------    

    public HeartSystem heartsystem;
    [SerializeField] private GameObject message, Dragon, LetterIcon, heart, heart1, heart2;
    [SerializeField] private GameObject tree, source, gameOver, fog, oranberry, ScoreIcon;
    [SerializeField] private Text scoreText;


    private float interval = 1.5f;
    private bool started, fogActived, oranBerryActived, pause;
    private int score, health;


    //----------------------------------------------------------------------------------------------------------------  


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //default values ​​when starting the game
    void Start()
    {
        score = 0;
        started = false;
        pause = false;
        InvokeRepeating("SpawnTrees", 0f, interval);//spawn trees 
    }

    // Update is called once per frame
    void Update()
    {

        // get the health value from heartsystem script
        health = heartsystem.GetHealth();




        // conditions to spawn fog
        if (score % 10 == 0 && score != 0 && !fogActived)
        {
            fogActived = true;
            for (int i = 0; i < 5; i++)// spawn 3 fogs
            {
                Instantiate(fog);

            }
        }

        // conditions to spawn oranBerry
        if (health < 3 && !oranBerryActived && !fogActived)
        {
            for (int i = 0; i < 1; i++)// spawn 1 oranBerry
            {
                Instantiate(oranberry);//spawn the berry 
            }
            oranBerryActived = true;
        }

        //changes the value of the variable fogActived to be used again
        if (score % 15 == 1)
        {
            fogActived = false;
        }

        //changes the value of the variable oranBerryActived to be used again
        if (health == 3 || score % 10 == 0)
        {
            oranBerryActived = false;
        }

        //starting the game
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(message);
            Dragon.SetActive(true);
            started = true;
            
            //UI changes when game starts
            LetterIcon.SetActive(true);
            heart.SetActive(true);
            heart1.SetActive(true);
            heart2.SetActive(true);
            ScoreIcon.SetActive(true);

        }


        //pause the game
        if (Input.GetKeyDown(KeyCode.P))
        {
            //pause
            if (!pause)
            {
                Time.timeScale = 0;
                pause = true;
            }
            //resume
            else
            {
                Time.timeScale = 1;
                pause = false;
            }

        }
         

    }

    //function responsible for spawning trees
    private void SpawnTrees()
    {
        if (!started) return;

        Instantiate(
            tree,                         // Instantiate the trees
            source.transform.position,   // At the position of the source object
            Quaternion.identity         // With default rotation (no rotation, identity)
        );
    }


    //----------------------------------------publicFunctions----------------------------------------


    //function responsible for converting the int variable Score to String
    public void IncreaseScore(int score)
    {
        this.score += score;
        scoreText.text = this.score.ToString();
    }

    //function to use when the player hits the ground or collides with trees
    public void GameOver()
    {
        //UI changes when game over
        gameOver.SetActive(true);
        heart.SetActive(false);
        heart1.SetActive(false);
        heart2.SetActive(false);
        Time.timeScale = 0;
    }

    //function to be used in other scripts to import the score value
    public int GetScore()
    {
        return score;
    }

    ////function to be used in other scripts to check if the game has already started
    public bool GetStarted()
    {
        return started;
    }

    //function to exit the game
    public void Exit()
    {
        Application.Quit();
    }

   
    
    
//-----------------------------------------------------------------------------------------------




}