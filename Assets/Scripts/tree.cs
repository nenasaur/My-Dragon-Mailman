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
    [SerializeField] private GameObject oranBerry;

    //---------------------------------------------------------------------------------------- 





    // Start is called before the first frame update
    void Start()
    {
        //part responsible for changing the height of trees
        float randomY = Random.Range(-0.4f, 0.4f);
        transform.position = new Vector2(transform.position.x, randomY);


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

    //fuction responsible for destroying the oran berry when the dragon collides with it
     void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            Destroy(oranBerry);
        }
    }
  
}  