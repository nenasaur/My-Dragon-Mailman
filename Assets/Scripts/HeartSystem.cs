using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartSystem : MonoBehaviour
{


   //----------------------------------------variables---------------------------------------
    public int health = 3;
    public int maxHealth = 3;

   //prevents the berry from recovering more HP t
    private bool berryUsed = false;
    public Image[] heart;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    [SerializeField] private AudioClip deathSound, hitSound;
  //----------------------------------------------------------------------------------------


    // Update is called once per frame
    void Update()
    {
        //calls the function
        HealthLogic();

        //checks if the player has lost all lives
        if (health < 1)
        {
            GameController.instance.GameOver();
            AudioController.instance.PlayAudioClip(deathSound, false);
        }
    }

    void HealthLogic()
    {
        //max life is three.
        if (health > maxHealth)
        {
            //does not allow you to exceed the maximum number of lives
            health = maxHealth;
        }


        //sets the hearts sprite according to the player's health
        for (int i = 0; i < 3; i++)
        {
            if (i < health)
            {
                heart[i].sprite = fullHeart;
            }
            else
            {
                heart[i].sprite = emptyHeart;
            }
        }
    }

    //function that checks whether the player collided with the ground or trees
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Tree") || other.gameObject.CompareTag("Ground"))
        {
            AudioController.instance.PlayAudioClip(hitSound, false);
            health--;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //checks if the dragon is in contact with the berry
        if (other.CompareTag("oranBerry") && !berryUsed)
        {

            health++;
            //the berry recovers one point of hp
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("oranBerry"))
        {
            //resets the variable so it can be used again
            berryUsed = false;
        }
    }
   
    //function to be used in other scripts to import the health value
    public int GetHealth()
    {
        return health;
    }
    
}
