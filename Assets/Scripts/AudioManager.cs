using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private AudioSource audioSr;

    public AudioClip disparo;
    public AudioClip salto;
    public AudioClip moneda;



    private void Awake()
    {
        Instance = this;
        audioSr = GetComponent<AudioSource>();

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSound(AudioClip clip)
    {
        audioSr.PlayOneShot(clip); //Suenan todos los sonidos, pero si usas .Play solo suena uno

    }

    public void playDisparo()
    {
        playSound(disparo);
    }
}
