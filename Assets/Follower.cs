using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{

    public Transform player2Follow; //la posicion de Rambo, del player principal
    public float stopDistance;
    public float speed = 1;

    // Start is called before the first frame update
    public virtual void Start() //Virtual es para poder sobreescribir el método específico
    {
        if (player2Follow == null) //Si no tienes un player a quien seguir, buscalo por el tag PLAYER
        {
            player2Follow = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (player2Follow != null)
        {
            if (Vector2.Distance (transform.position, player2Follow.position) > stopDistance)
            {
                Vector2 direccion;
                direccion = Vector2.MoveTowards(transform.position, player2Follow.position, speed * Time.deltaTime);
                this.transform.position = direccion;
            }



        }



        Vector3 direction = player2Follow.transform.position - transform.position; //Posición del Player - el de Charmy(mi follower). FLIPEAR
        if (direction.x >= 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        } else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

    }

    public void CogerPlayer()
    {
        player2Follow = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

}
