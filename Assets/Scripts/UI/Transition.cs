using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    private Animator _transicion;
    public string _escena;
    // Start is called before the first frame update
    void Start()
    {
        _transicion = GetComponent<Animator>();
        
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            LoadScene(_escena);
        }
    }

    public void LoadScene(string _escena) //scene era una variable local que no podía llamar desde Update
    {
        StartCoroutine(Transicionar(_escena));
    }

    IEnumerator Transicionar(string _escena) //CORRUTINA
    {
        _transicion.SetTrigger("exit"); // la animacion se ejecuta
        yield return new WaitForSeconds(2); //espero un poco xq sino no veo la animación
        SceneManager.LoadScene(_escena); //en lugar de ser 0 o 1 o 2 es el nombre de la escena en Unity

    }

}
