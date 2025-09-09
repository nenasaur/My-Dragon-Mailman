//**************************************** DragonScript.cs *****************************************

//---------------calling the libraries---------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//---------------------------------------------------
public class DragonScript : MonoBehaviour
{

    //----------------------------------------variables---------------------------------------  
    [SerializeField] private float jumpSpeed;
    
    [SerializeField] private AudioClip jumpSound, deathSound, scoreSound;
    private bool jumping;
    private Rigidbody2D rb;
    //----------------------------------------------------------------------------------------  


    // Start is called before the first frame update
    void Start()
    {
        //default values ​​when starting the game
        jumping = false;
        rb = GetComponent<Rigidbody2D>();

    }
    // Update is called once per frame
    void Update()
    {

        //space key will be the button for the dragon to jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumping = true; 
        }    
      
    }



    void FixedUpdate()
    {
        //jumping will be true if the space bar is pressed
        if (jumping)
        {
            AudioController.instance.PlayAudioClip(jumpSound, false);
            rb.velocity = Vector2.up * jumpSpeed;
            jumping = false;
        }
        
    }

    //function responsible for increasing the score
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Score"))
        {
            AudioController.instance.PlayAudioClip(scoreSound, false);
            GameController.instance.IncreaseScore(1);

        }
    }

    //function that checks whether the player collided with the ground or trees
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Tree") || other.gameObject.CompareTag("Ground"))
        {
            AudioController.instance.PlayAudioClip(deathSound, false);
            //   GameController.instance.GameOver();
        }
    }
    
}
