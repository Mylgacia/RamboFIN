using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject player;
    public float _ultimoDisparo;
    public int Health = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.transform.position - transform.position; //Posición del Player - el de Charmy(mi follower). FLIPEAR
        if (direction.x >= 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        }
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        float distance = Mathf.Abs(player.transform.position.x - transform.position.x); // en teoría es un vector3


        if (distance < 10.0f && Time.time > _ultimoDisparo + 0.25f ) // Si la distancia entre ellos es menor a 2.0 (2 metros)
        {
            Shoot();
            _ultimoDisparo = Time.time;
        }

    }

    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 1.0f)
        {
            direction = Vector3.right;
        }
        else
        {
            direction = Vector3.left;
        }


        GameObject bullet = Instantiate(bulletPrefab, transform.position + direction, Quaternion.identity); // Instanciamos la bala y vamos a mirar dentro de ella
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }

    private void Dañar()
    {
        Health = Health - 1;
        if (Health == 0)
        {
            Destroy(gameObject);
        }
    }

    public void CogerRambo()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bala"))
        {
            Dañar();
        }


    }

   /* private void OnCollisionEnter2D(Collision2D other)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {
            Dañar();
        }

       
    }*/





}
