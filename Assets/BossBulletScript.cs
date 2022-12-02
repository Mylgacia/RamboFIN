using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletScript : MonoBehaviour
{
    private Rigidbody2D rb_bullet;
    private Vector3 Direction;
    public float speed = 100;
    public Transform rambo;


    private void Awake()
    {
        rb_bullet = GetComponent<Rigidbody2D>();
        
    }
    

    private void FixedUpdate()
    {
        rb_bullet.velocity = Direction.normalized * speed * Time.deltaTime;
    }
    public void SetDirection(Vector3 direction)
    {
        Direction = direction;
        Direction = new Vector3(direction.x, direction.y -1.0f, direction.z);
        Invoke("Destruir", 0);
    }

    public void Destruir()
    {
        Destroy(gameObject, 2);
    }

}
