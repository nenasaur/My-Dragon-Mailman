using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    [SerializeField] private float speed;


    // Start is called before the first frame update
    void Start()
    {
        float randomY = Random.Range(-0.4f, 0.4f);
        transform.position = new Vector2(transform.position.x, randomY);


    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(
            transform.position.x + speed * Time.deltaTime,
            transform.position.y
        );
        if (transform.position.x > 10)
        {
            Destroy(gameObject);
        }
    }

}
    