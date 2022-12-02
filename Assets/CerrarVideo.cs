using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CerrarVideo : MonoBehaviour
{
    [SerializeField] private VideoPlayer video;

    private void Awake()
    {
        video = GetComponent<VideoPlayer>();
        video.Play();
        video.loopPointReached += Cerrar;
    }



    void Cerrar(VideoPlayer vp)
    {
        gameObject.SetActive(false);
    }
}
