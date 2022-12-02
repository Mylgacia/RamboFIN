using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_Bullet : MonoBehaviour
{

    [SerializeField] private GameObject efecto;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Bala"))
        {
            Instantiate(efecto, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);

        }

    }

}
