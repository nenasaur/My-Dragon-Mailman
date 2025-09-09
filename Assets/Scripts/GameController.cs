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

    [SerializeField] private GameObject message, Dragon;
    [SerializeField] private GameObject tree, source, gameOver, fog;
    [SerializeField] private GameObject paichirisu, happyPaichirisu, noctowl, happyNoctolw, swablu, happySwablu;

    [SerializeField] private Text scoreText;
    private float interval = 1.5f;
    private bool started, fogActived;


    private int score;
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
            Destroy(message);
            Dragon.SetActive(true);
            started = true;
        }

        //-------------------------------------------receiveALetter-------------------------------------------

        //                            conditions to pokemon receive the letter

        if (score == 25 && !paichirisu.activeInHierarchy)
        {
            paichirisu.SetActive(true);
            Invoke("spawnPaichirisu", 1.5f);
            Invoke("desablePokemon", 2f);


        }

        if (score == 50 && !noctowl.activeInHierarchy)
        {
            noctowl.SetActive(true);
            Invoke("spawnNoctowl", 1.5f);
            Invoke("desablePokemon", 2f);

        }
        if (score == 75 && !swablu.activeInHierarchy)
        {
            swablu.SetActive(true);
            Invoke("spawnSwablu", 1.5f);
            Invoke("desablePokemon", 2f);
        }

        //----------------------------------------------------------------------------------------------------

    }

    //---------------------------------receiveALetterMethods-----------------------------------------------

    //        methods responsible for showing the Pokémon receiving the card and then disabling them

    //Paichirisu method
    void spawnPaichirisu()
    {
        paichirisu.SetActive(false);
        happyPaichirisu.SetActive(true);
    }

    //Noctowl method
    void spawnNoctowl()
    {
        noctowl.SetActive(false);
        happyNoctolw.SetActive(true);
    }

    //Swablu method
    void spawnSwablu()
    {
        swablu.SetActive(false);
        happySwablu.SetActive(true);

    }

    //method to disable the pokémon
    void desablePokemon()
    {
        //this method does nothing
        happyPaichirisu.SetActive(false);
        happyNoctolw.SetActive(false);
        happySwablu.SetActive(false);
    }

    //----------------------------------------------------------------------------------------------------

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

    public bool GetStarted()
    {
        return started;
    }

    
    
//-----------------------------------------------------------------------------------------------




}

