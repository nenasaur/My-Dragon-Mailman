//**************************************** AudioController.cs *****************************************

//---------------calling the libraries---------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//---------------------------------------------------

public class AudioController : MonoBehaviour
{

    //----------------------------------------variables---------------------------------------
    public static AudioController instance;

    [SerializeField] private AudioSource soundSource;
     [SerializeField] private AudioSource backgorundsoundSource;
    [SerializeField] private AudioClip soundTrack;
    
    //----------------------------------------------------------------------------------------

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
        backgorundsoundSource.clip = soundTrack;
        backgorundsoundSource.loop = true;
        backgorundsoundSource.Play();
    }
    

//function responsible for playing audioclips 
    public void PlayAudioClip(AudioClip sound, bool loop)
    {
        soundSource.clip = sound;
        soundSource.loop = loop;
        soundSource.Play();
    }
}