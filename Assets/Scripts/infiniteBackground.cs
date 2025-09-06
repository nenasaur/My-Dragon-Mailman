//**************************************** infiniteBackground.cs *****************************************

//---------------calling the libraries---------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//---------------------------------------------------

public class infiniteBackground : MonoBehaviour

{


    private float backgroundVelocity = 0.5f; // speed of background movement  

    private int Score = GameController.instance.GetScore();// get the Score from GameController


    void Update()
    {
        // the method is called to perform the movement of the background
        backgroundMoviment();
        
    }

    //method that defines the movement of the background
    void backgroundMoviment()
    {
        Vector2 displacement = new Vector2(Time.time * - backgroundVelocity, 0);
        GetComponent<Renderer>().material.mainTextureOffset = displacement;
    }
}
