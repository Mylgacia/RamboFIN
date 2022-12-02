using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicaBrillo : MonoBehaviour
{
    public Slider sliderBrillo;
    public float sliderValue;
    public Image panelBrillo;
    //public Image panelMenu;

    // Start is called before the first frame update
    void Start()
    {
        sliderValue = PlayerPrefs.GetFloat("brillo", 0.2f);
        sliderBrillo.value = sliderValue;
        panelBrillo.color = new Color(panelBrillo.color.r, panelBrillo.color.g, panelBrillo.color.b, sliderValue);

       // panelMenu.color = new Color(panelMenu.color.r, panelMenu.color.g, panelMenu.color.b, sliderValue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSlider(float value)
    {
        sliderValue = value;
        PlayerPrefs.SetFloat("brillo", sliderValue);
        panelBrillo.color = new Color(panelBrillo.color.r, panelBrillo.color.g, panelBrillo.color.b, sliderValue);

        //panelMenu.color = new Color(panelMenu.color.r, panelMenu.color.g, panelMenu.color.b, sliderValue);

    }
}
