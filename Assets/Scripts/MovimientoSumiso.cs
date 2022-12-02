using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoSumiso : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private Transform[] puntosMovimiento;
    [SerializeField] private float distanciaMinima;

    private int siguientePaso = 0;
    private SpriteRenderer sprBat;



    // Start is called before the first frame update
    void Start()
    {
        //siguientePaso = Random.Range(0, puntosMovimiento.Length);
        sprBat = GetComponent<SpriteRenderer>();
        Flipear();

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, puntosMovimiento[siguientePaso].position, velocidadMovimiento*Time.deltaTime);

        if (Vector2.Distance(transform.position, puntosMovimiento[siguientePaso].position) < distanciaMinima)
        {
            siguientePaso += 1;
            //siguientePaso = Random.Range(0, puntosMovimiento.Length);
            if (siguientePaso >= puntosMovimiento.Length)
            {
                siguientePaso = 0;
            }
            
            Flipear();


        }
        

    }

    private void Flipear()
    {
        if (transform.position.x < puntosMovimiento[siguientePaso].position.x)
        {
            sprBat.flipX = true;
        }
        else { sprBat.flipX = false; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.Damage();
            CineMachineScript.Instance.MoverCamara(5.0f, 5.0f, 0.5f);
        }



    }




}
