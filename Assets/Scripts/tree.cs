//**************************************** tree.cs *****************************************

//---------------calling the libraries---------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//---------------------------------------------------

public class trees : MonoBehaviour
{

    //----------------------------------------variables---------------------------------------   
    private float speed = 5f;// tree speed

    // get the score from GameController
    private int Score = GameController.instance.GetScore();

     [SerializeField] private GameObject ariados, paichirisu, noctowl,  swablu;
    [SerializeField] private GameObject happyAriados, happyPaichirisu, happyNoctolw, happySwablu;

    //---------------------------------------------------------------------------------------- 





    // Start is called before the first frame update
    void Start()
    {
        //part responsible for changing the height of trees
        float randomY = Random.Range(-0.4f, 0.4f);
        transform.position = new Vector2(transform.position.x, randomY);

        //-------------------------------------------receiveALetter-------------------------------------------

        //                     conditions to choose the Pokémon that will receive the letter

        /*                                     priority table            

                                          +---------------+------+           
                                          |     pokemon   | Nº   |
                                          +---------------+------+ 
                                          |    noctwol    | 1º   |
                                          +---------------+------+ 
                                          |    ariados    | 2º   |
                                          +---------------+------+ 
                                          |    swablu     | 3º   |
                                          +---------------+------+ 
                                          |  paichirisu   |  4º  |
                                          +---------------+------+ 
               
        */
             
        

            // 1st priority: Noctowl
            if (Score % 7 == 0 && Score != 0 && Score > 50)
            {
                noctowl.SetActive(true);
                return; 
            }

            // 2st priority: Ariados
            if (Score % 5 == 0 && Score != 0 && Score > 15)
            {
                ariados.SetActive(true);
                return;
            }

            // 3st priority: Swablu
            if (Score % 3 == 0 && Score != 0)
            {
                swablu.SetActive(true);
                return;
            }

            // 4st priority: Pachirisu
            if (Score % 2 == 0 || Score == 0 || Score == 1 || Score % 2 == 1)
            {
                paichirisu.SetActive(true);
                return;
            }
        
         //----------------------------------------------------------------------------------------------------

    }

    // Update is called once per frame
    void Update()
    {

        //part of the code that changes the X-axis position of the trees
        transform.position = new Vector2(
            transform.position.x + speed * Time.deltaTime,
            transform.position.y
        );

        //obstacles are destroyed after exiting the game camera
        if (transform.position.x > 10)
        {
            Destroy(gameObject);
        }

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

   //Ariados method
    void spawnAriados()
    {
        ariados.SetActive(false);
        happyAriados.SetActive(true);
    }

    //----------------------------------------------------------------------------------------------------



    

    //function that checks when a Pokémon collides with the player
     void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            //what to do according to the pokemon in the tree 
        
            //for noctowl
            if (noctowl.activeInHierarchy)
            {
                paichirisu.SetActive(false);
                ariados.SetActive(false);
                swablu.SetActive(false);
                Invoke("spawnNoctowl", 0.3f);
            }
            
            //for paichirisu
            if (paichirisu.activeInHierarchy)
            {
                Invoke("spawnPaichirisu", 0.3f);
            }

            //for swablu 
            if (swablu.activeInHierarchy)
            {
                paichirisu.SetActive(false);
                Invoke("spawnSwablu", 0.3f);
               
            }

             //for ariados
            if (ariados.activeInHierarchy)
            {
                swablu.SetActive(false);
                paichirisu.SetActive(false);
                Invoke("spawnAriados", 0.3f);
                
            }
           
        }
    }
}