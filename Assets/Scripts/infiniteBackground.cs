using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infiniteBackground : MonoBehaviour

{


    private float backgroundVelocity = 0.5f;    // Start is called before the first frame update

    // Update is called once per frame
    private int Score = GameController.instance.GetScore();
    void Update()
    {
        backgroundMoviment();
        
    }

    void backgroundMoviment()
    {
        Vector2 deslocamento = new Vector2(Time.time * - backgroundVelocity, 0);
        GetComponent<Renderer>().material.mainTextureOffset = deslocamento;
    }
}
