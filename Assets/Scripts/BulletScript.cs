using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    //public AudioClip sonidoBala;
    public float speed = 30;
    private Rigidbody2D rb_bullet;
    private Vector2 Direction;
    private SpriteRenderer spr;
    //[SerializeField] private GameObject efecto;

    private void Awake()
    {
        rb_bullet = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        //Camera.main.GetComponent<AudioSource>().PlayOneShot(sonidoBala);

        //AudioManager.Instance.playDisparo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
       // rb_bullet.velocity = Vector2.right * speed;
        rb_bullet.velocity = Direction * speed;
        Debug.Log(Direction);
    }

    public void SetDirection(Vector2 direction)
    {
        
        Direction = direction; // el valor Vector2 que te mande desde fuera, conviertelo en Direction y aplica la fórmula de arriba 
        if (direction == Vector2.left)
        {
            spr.flipX = true;
        }
        else spr.flipX = false;

        
    }

    public void Destruir()
    {
        
        //Instantiate(efecto, transform.position, Quaternion.identity);       
        Destroy(gameObject);
    }

    
}
