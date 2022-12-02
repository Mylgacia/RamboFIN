using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    
    private SpriteRenderer spr;
    private Rigidbody2D _rbPlayer;
    private Animator _animator;

    [SerializeField] private float speed = 0.0f;
    [SerializeField] private Vector2 movement;
    [SerializeField] private int jumpForce;
    [SerializeField] private bool Grounded = false;

    //MUERTE
    public PlayerMovement script;

    private bool facingRight = false;

    //BALA
    public GameObject bulletPrefab;
    public GameObject weapon;
    //public BulletScript bs;


    private void Awake()
    {
        _rbPlayer = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        movement = new Vector2(horizontal, 0.0f);

       // _animator.SetBool("isIdle", movement == Vector2.zero);
        _animator.SetBool("isIdle", horizontal == 0.0f);

        Debug.DrawRay(transform.position, Vector3.down, Color.red);

        if (Physics2D.Raycast(transform.position, Vector3.down, 1f))
        {
            Grounded = true;
        }
        else
        {
            Grounded = false;
        }


        if (Input.GetKeyDown(KeyCode.Space) &&  Grounded == true)
        {
            Jump();
        }

        if (horizontal > 0.0f && facingRight == true)
        {
            Flip();

        } else if (horizontal < 0.0f && facingRight == false)
        {
            Flip();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }



    }

    private void FixedUpdate()
    {
        float horizontalVelocity = movement.x * speed; // Convertimos float en Vector2

        _rbPlayer.velocity = new Vector2( horizontalVelocity, _rbPlayer.velocity.y);

    }

    private void Flip()
    {
        facingRight = !facingRight;
        float localScaleX = transform.localScale.x;
        localScaleX = localScaleX * -1f;

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Jump()
    {
        _rbPlayer.AddForce(Vector2.up * jumpForce); //Solucionar ForceMode

    }

    private void Shoot()
    {
       Vector2 direction;
        if (transform.localScale.x > 0.0f)
        {
            direction = Vector2.right;
        }
        else
        {
            direction = Vector2.left;
        }

        


       GameObject bullet = Instantiate(bulletPrefab, weapon.transform.position, Quaternion.identity); // Instanciamos la bala y vamos a mirar dentro de ella
        bullet.GetComponent<BulletScript>().SetDirection(direction);
       // bs.SetDirection(direction);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plataforma"))
        {
            transform.parent = collision.transform;
           
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plataforma"))
        {
            transform.parent = null;

        }
    }

    private void LateUpdate()
    {
        //_animator.SetBool("isIdle",)
        _animator.SetBool("isGrounded", Grounded);
    }

    public void Morir()
    {
        _animator.SetTrigger("Muerte");
       // script.enabled = false;
        Destroy(gameObject, 3);

    }



}
