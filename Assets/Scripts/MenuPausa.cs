using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;

    // Start is called before the first frame update
   
    public void Pausa()
    {
        Time.timeScale = 0f;
      
        botonPausa.SetActive(false); //puede ser una tecla
        menuPausa.SetActive(true); // aparecerá el menu cuando pulsemos el boton con Onclick()

    }

    public void Reanudar()
    {
        Time.timeScale = 1f;

        botonPausa.SetActive(true);
        menuPausa.SetActive(false); //estaba en true y no se quitaba el panel
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Cerrar()
    {
        Debug.Log("Cerrar juego");
        Application.Quit();
    }
}
