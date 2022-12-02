using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPuntos : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private Transform[] puntosMovimiento;
    [SerializeField] private float distanciaMinima;

    private int numeroAleatorio;
    private SpriteRenderer sprBat;



    // Start is called before the first frame update
    void Start()
    {
        numeroAleatorio = Random.Range(0, puntosMovimiento.Length);
        sprBat = GetComponent<SpriteRenderer>();
        Flipear();

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, puntosMovimiento[numeroAleatorio].position, velocidadMovimiento*Time.deltaTime);

        if (Vector2.Distance(transform.position, puntosMovimiento[numeroAleatorio].position) < distanciaMinima)
        {
            numeroAleatorio = Random.Range(0, puntosMovimiento.Length);
            Flipear();
        }

    }

    private void Flipear()
    {
        if (transform.position.x < puntosMovimiento[numeroAleatorio].position.x)
        {
            sprBat.flipX = true;
        }
        else { sprBat.flipX = false; }
    }

}
