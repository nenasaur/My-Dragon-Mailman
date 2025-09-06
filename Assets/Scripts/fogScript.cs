//**************************************** fogScripts.cs *****************************************

//---------------calling the libraries---------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//---------------------------------------------------

public class fogScript : MonoBehaviour
{


    //----------------------------------------variables---------------------------------------  

    // get the score from GameController
    private int Score = GameController.instance.GetScore();
    private float speed = 2.5f;// fog speed 

    //----------------------------------------------------------------------------------------


    // Start is called before the first frame update
    void Start()
    {
         //part responsible for changing the height of fogs
        float randomY = Random.Range(-3f, 3f);
        transform.position = new Vector2(transform.position.x, randomY);
    }

    // Update is called once per frame
    void Update()
    {
        //part of the code that changes the X-axis position of the fogs

        transform.position = new Vector2(
            transform.position.x + speed * Time.deltaTime,
            transform.position.y
        );

        //fogs are destroyed after exiting the game camera
        if (transform.position.x > 8)
        {
            Destroy(gameObject);
        }

    }
}
