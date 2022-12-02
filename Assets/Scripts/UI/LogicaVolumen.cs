using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicaVolumen : MonoBehaviour
{
    public Slider sliderVolumen;
    public float sliderValue;
    public GameObject imagenMute;

    // Start is called before the first frame update
    void Start()
    {

        sliderValue = PlayerPrefs.GetFloat("volumen", 0.5f);
        AudioListener.volume = sliderValue; //Necesita un AudioSource la camara
        sliderVolumen.value = sliderValue;
        RevisarSiEstoyMute();

    }

    // Update is called once per frame
    public void ChangeSliderV(float value)
    {
        sliderValue = value;
        PlayerPrefs.SetFloat("volumen", sliderValue);
        AudioListener.volume = sliderValue;
        RevisarSiEstoyMute();
        

    }

    public void RevisarSiEstoyMute()
    {
       if (sliderValue == 0)
        {
            imagenMute.SetActive(true);
        }
        else imagenMute.SetActive(false);
    }
}
