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

    //----------------------------------------variables---------------------------------------    

    [SerializeField] private GameObject message, Dragon;
    [SerializeField] private GameObject tree, source, gameOver, fog;

    [SerializeField] private Text scoreText;
    private float interval = 1.5f;
    private bool started, fogActived;
    private int score;
    //----------------------------------------------------------------------------------------    


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
        InvokeRepeating("SpawnTrees", 0f, interval);

    }

    // Update is called once per frame
    void Update()
    {
        // conditions to spawn fog
        if (score % 10 == 0 && score != 0 && !fogActived)
        {
            for (int i = 0; i < 3; i++)// spawn 3 fogs
            {
                Instantiate(fog);

            }
            fogActived = true;
        }
        if (score % 10 == 1)
        {
            fogActived = false;
        }

        //starting the game
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // message.SetActive(true);
            Destroy(message);
            Dragon.SetActive(true);
            started = true;

        }
    }

    //function responsible for spawning trees
    private void SpawnTrees()
    {
        if (!started) return;

        Instantiate(
            tree,                      // Instantiate the trees
            source.transform.position,  // At the position of the source object
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

        gameOver.SetActive(true);
        Time.timeScale = 0;
    }

    //function to be used in other scripts to import the score value
    public int GetScore()
    {
        return score;
    }
//-----------------------------------------------------------------------------------------------
    

    

}

