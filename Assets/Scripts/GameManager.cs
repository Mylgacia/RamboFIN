using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [Header ("PUNTOS")]
    public int score = 0;
    public TextMeshProUGUI textpuntos;

    [Header("VIDAS")]
    [SerializeField] private int vidas = 3;
    [SerializeField] private List<GameObject> listaVidas;
    [SerializeField] private Sprite vidaDesactivada;

    [SerializeField] private Sprite vidaActivada;


    public PlayerMovement playerScript; //Estoy enlazando el GameManager con el script del player PlayerMovement

    //MUERTE
    public GameObject panelGameOver;
    public GameObject panelPausa;

    //RESPAWN
    public GameObject playerPrefab;
    public Transform retryPosition;
    [SerializeField] private Follower fol;
    [SerializeField] private GruntScript _gruntScript;

    //INVULNERABLE
    [SerializeField] private bool invencible;


    //PANTALLA DE COLOR
    public Color hurt;
    public Color normal;
    public Image Imagendaño;

    //public int vidas = 0;
    //public TextMeshProUGUI textvidas;

    private void Awake()
    {
        if( Instance == null)
        {
            
            Instance = this;
            DontDestroyOnLoad(gameObject);


        }
        else
        {
            Destroy(gameObject);
        }
        
        


    }
    // Start is called before the first frame update
    void Start()
    {
       // vidas = 3; 
       // textvidas.text = "" + vidas.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addScore(int puntos)
    {
        score = score + puntos; // score += puntos
        textpuntos.text = "" + score.ToString();
    }

    public void RestarVidas(int indice)
    {
        Image medalla = listaVidas[indice].GetComponent<Image>();
        medalla.sprite = vidaDesactivada;

        //vidas = vidas + life;
        //textvidas.text = "" + vidas.ToString();
    }

    public void FullVidas(int indice)
    {
        for (indice = 0; indice < 3; indice++)
        {
            Image medalla = listaVidas[indice].GetComponent<Image>();
            medalla.sprite = vidaActivada;

        }

        

    }

    public void Damage()
    {
        if (invencible == false)
        {
            vidas--; // vidas = vidas -1;
            Imagendaño.color = hurt; 
           RestarVidas(vidas); // voy a mandarle un int 2, despues un 1, 0, -1
           StartCoroutine(Invulnerable());

        }
        

        if(vidas == 0)
        {
            playerScript.Morir(); //Estoy llamando al script PlayerMovement, su método morir que accionará la animación
            Debug.Log(vidas); //sácame por consola lo que te ponga dentro
            Invoke("gameOver", 4);
        }


    }

    IEnumerator Invulnerable()
    {
        if (vidas > 0) //if en la corrutina CACA
        {
            invencible = true;
            playerPrefab.GetComponent<Animator>().SetTrigger("Damage");  //hay que crear la animacion en Animator de Daño, y ponerle un bool Damage
           
            yield return new WaitForSeconds(2); 
            Imagendaño.color = normal;

            invencible = false;
            //playerPrefab.GetComponent<Animator>().SetBool("Damage", false);

        }


    }


    public void gameOver() //hemos creado panel de GameOver con un Botón de retry
    {
        panelGameOver.SetActive(true);
        panelPausa.SetActive(false);
        Time.timeScale = 0f;
    }




    public void Retry() //Quitamos paneles, volvemos el tiempo a 1 e instanciamos el prefab del player
    {
        GameObject player = Instantiate(playerPrefab, retryPosition.position, Quaternion.identity);
        //ayerScript.script.enabled = true;

        panelGameOver.SetActive(false);
        panelPausa.SetActive(true);
        Time.timeScale = 1f;
        vidas = 3;
        
        
        fol.CogerPlayer();
        _gruntScript.CogerRambo();
        CineMachineScript.Instance.SeguirNewPlayer();
        FullVidas(0);

        //GameObject playerClone = PlayerMovement.F
        //playerScript = playerPrefab.GetComponent<PlayerMovement>();
        playerScript = FindObjectOfType<PlayerMovement>();
        

    }
}
