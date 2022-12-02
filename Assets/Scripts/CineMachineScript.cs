using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CineMachineScript : MonoBehaviour
{
    public static CineMachineScript Instance;
    private CinemachineVirtualCamera cVirtualCamera;
    private CinemachineBasicMultiChannelPerlin basicPerlin;

    private float tiempoMovimiento;
    private float tiempoMovimientoTotal;

    private float intensidadInicial;

    private void Awake()
    {
        Instance = this;
        cVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        basicPerlin = cVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() //Aquí vamos a calcular el tiempo del shake
    {
        
        if(tiempoMovimiento > 0)
        {
            tiempoMovimiento = tiempoMovimiento - Time.deltaTime;
            basicPerlin.m_AmplitudeGain = Mathf.Lerp(intensidadInicial, 0, 1 - (tiempoMovimiento / tiempoMovimientoTotal));
        }

    }

    public void MoverCamara(float intensidad, float frecuencia, float tiempo)
    {

        basicPerlin.m_AmplitudeGain = intensidad;
        basicPerlin.m_FrequencyGain = frecuencia;
        intensidadInicial = intensidad;
        tiempoMovimientoTotal = tiempo;
        tiempoMovimiento = tiempo;

    }

    public void SeguirNewPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        CinemachineVirtualCamera cinemachineVirtual = FindObjectOfType<CinemachineVirtualCamera>();
        cinemachineVirtual.m_Follow = player.transform; 

    }
}
