using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeteccionGolpe : MonoBehaviour
{
    [SerializeField] float retardo = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    //[SerializeField] AudioClip crashSFX;
    PlayerController controlador;
    bool haMuerto = false;

    private void Start()
    {
        controlador = GetComponent<PlayerController>();
    }

    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Suelo" && !haMuerto)
        {
            haMuerto = true;
            //FindObjectOfType<PlayerController>().PararControl();
            controlador.PararControl();
            crashEffect.Play();
            //GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", retardo);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
