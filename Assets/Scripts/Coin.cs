using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int puntosMoneda = 100;
   //[SerializeField] private int vidasPlayer = -1;
    //public CineMachineScript cms;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetKey(KeyCode.P))
        {
            

        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {

            GameManager.Instance.addScore(100); // vale 100
            //GameManager.Instance.RestarVidas(vidasPlayer);
            CineMachineScript.Instance.MoverCamara(5.0f, 5.0f, 0.5f);

            GameManager.Instance.Damage();
           // Getkilled();
        }

    }
    private void Getkilled()
    {

        gameObject.SetActive(false);
        //Invoke("Respawn", 3);

    }

    private void Respawn()
    {
        gameObject.SetActive(true);
    }



}
