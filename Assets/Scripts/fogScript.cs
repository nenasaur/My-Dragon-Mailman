using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fogScript : MonoBehaviour
{
     private int Score = GameController.instance.GetScore();
    private float speed = 2.5f;


    // Start is called before the first frame update
    void Start()
    {
        float randomY = Random.Range(-3f, 3f);
        transform.position = new Vector2(transform.position.x, randomY);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(
            transform.position.x + speed * Time.deltaTime,
            transform.position.y
        );
        if (transform.position.x > 8)
        {
            Destroy(gameObject);
        }

    }
}
