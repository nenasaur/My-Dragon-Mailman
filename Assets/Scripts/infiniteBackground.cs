//**************************************** infiniteBackground.cs *****************************************

//---------------calling the libraries---------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//---------------------------------------------------

public class infiniteBackground : MonoBehaviour

{


    private float backgroundVelocity = 0.5f; // speed of background movement  

    //check if the game was started by GameController
    private bool started = GameController.instance.GetStarted();
    
    // get the Score from GameController
    private int Score = GameController.instance.GetScore();


    void Update()
    {
        
        //Check if there was a change in the started value
        started = GameController.instance.GetStarted();

   
        // the method is called to perform the movement of the background
        if (started)
        {
            backgroundMoviment();
        }
        
    }

    //method that defines the movement of the background
    void backgroundMoviment()
    {
        Vector2 displacement = new Vector2(Time.time * - backgroundVelocity, 0);
        GetComponent<Renderer>().material.mainTextureOffset = displacement;
    }
}
