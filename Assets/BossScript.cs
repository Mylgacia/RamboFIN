using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public Transform player;
    public Transform mouth;
    public GameObject bossBullet;
    public float ultimoDisparo;

    //NUMERO ALEATORIO
    public float timer;
    public float Min;
    public float Max;
    

    // Update is called once per frame
    void Update()
    {
        if (Time.time > ultimoDisparo + timer) // si lo dejo en 0 lo ejecuta constantemente
        {
            timer = Random.Range(Min, Max); //(0.25,1)
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            Shoot();
            ultimoDisparo = Time.time;

        }
            
    }

    private void Shoot()
    {
        Vector3 direction = player.position;

        GameObject bullet = Instantiate(bossBullet, mouth.position + direction*0.1f, Quaternion.identity);
        bullet.GetComponent<BossBulletScript>().SetDirection(direction);

    }
}
