using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioDeEscena : MonoBehaviour
{
    public Transform puntoInicial;
    public GameObject personaje;

    // Start is called before the first frame update
    void Start()
    {
        personaje = GameObject.FindGameObjectWithTag("Player");
        puntoInicial = GameObject.FindGameObjectWithTag("PuntoInicial").transform;
        MoverAlPuntoInicial();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoverAlPuntoInicial()
    {
        personaje.transform.position = puntoInicial.position;
    }
}
