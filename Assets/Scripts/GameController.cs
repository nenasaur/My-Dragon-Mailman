using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [SerializeField] private GameObject message, Dragon;
    [SerializeField] private GameObject pipes, source, gameOver,fog;
    [SerializeField] private Text scoreText;
    private float interval = 1.5f;
    private bool started, fogActived;
    private int score;





    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        score = 0;
        started = false;
        InvokeRepeating("SpawnPipes", 0f, interval);
    }

    // Update is called once per frame
    void Update()
    {

        if (score % 10 == 0 && score != 0 &&   !fogActived)
        {
            for (int i = 0; i < 3; i++)
            {
                Instantiate(fog);
               
            }
            fogActived = true;
        }
        if (score % 10 == 1)
        {
            fogActived = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
            {
                // message.SetActive(true);
                Destroy(message);
                Dragon.SetActive(true);
                started = true;

            }
    }
    
     private void SpawnPipes()
    {
        if (!started) return;

        Instantiate(
            pipes,                      // Instancia os pilares
            source.transform.position,  // Na posição do objeto source
            Quaternion.identity         // Com rotação padrão (sem rotação, identidade)
        );
    }

     
    public void IncreaseScore(int score)
    {
        this.score += score;
        scoreText.text = this.score.ToString();
    }

    public void GameOver()
    {
        
        gameOver.SetActive(true);
        Time.timeScale = 0;
    }

    public int GetScore()
    {
        return score;
    }
}

