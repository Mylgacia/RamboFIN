using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrullar : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private float distancia;
    [SerializeField] private bool moviendoIzquierda;

    private Rigidbody2D rb_enemy;
    // Start is called before the first frame update
    private void Awake()
    {
        rb_enemy = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        RaycastHit2D informacionSuelo = Physics2D.Raycast(controladorSuelo.position, Vector2.down, distancia); //RaycastHit2D es true o false

        rb_enemy.velocity = new Vector2(velocidad, rb_enemy.velocity.y);


        if (informacionSuelo == false) //Si Raycast no detecta ningun collider, entra aquí o ejecuta esto
        {
            Girar();
        }

    }

    private void Girar()
    {
        moviendoIzquierda = !moviendoIzquierda;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        velocidad = velocidad * -1; // velocidad *= -1;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controladorSuelo.position, controladorSuelo.position + Vector3.down * distancia);
    }



}
