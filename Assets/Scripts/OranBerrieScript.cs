using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OranBerrieScript : MonoBehaviour
{
    private float speed = 5f;// berrie speed


    void Start()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        //part of the code that changes the X-axis position of the trees
        transform.position = new Vector2(
            transform.position.x + speed * Time.deltaTime,
            transform.position.y
        );

        //destroys itself if the player doesn't pick it up
        if (transform.position.x > 10)
        {
            Destroy(gameObject);
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.CompareTag("Player"))
        {
            //when it comes into contact with the player the GameObject is destroyed
            Destroy(gameObject);
        }
    }
   
}


