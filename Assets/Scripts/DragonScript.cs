using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonScript : MonoBehaviour
{
    [SerializeField] private float jumpSpeed;
    [SerializeField] private AudioClip jumpSound, deathSound;

    private bool jumping;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        jumping = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumping = true;
        }

    }
    void FixedUpdate()
    {
        if (jumping)
        {
            AudioController.instance.PlayAudioClip(jumpSound, false);
            rb.velocity = Vector2.up * jumpSpeed; // (0, 1) * jumpSpeed
            jumping = false;
        }
    }
    
     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Score"))
        {
            GameController.instance.IncreaseScore(1);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Tree") || other.gameObject.CompareTag("Ground"))
        {
            AudioController.instance.PlayAudioClip(deathSound, false);
            GameController.instance.GameOver();
        }
    }

}
