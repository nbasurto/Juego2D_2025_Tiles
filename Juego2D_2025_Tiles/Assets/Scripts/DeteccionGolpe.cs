using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeteccionGolpe : MonoBehaviour
{
    [SerializeField] ParticleSystem efectoMuerte;
    PlayerController controlador;
    [SerializeField]LayerMask layersMuerte;
    BoxCollider2D cuerpo;
    // Start is called before the first frame update
    void Start()
    {
        controlador = GetComponent<PlayerController>();
        cuerpo = GetComponent<BoxCollider2D>();
    }

   

    private void Update()
    {
        /*//if (collision.gameObject.CompareTag("Pinchos") || collision.gameObject.CompareTag("Enemigo"))
        if(cuerpo.IsTouchingLayers(layersMuerte))
        {
            Debug.Log("¡El personaje colisiona a un enemigo!");
            controlador.PararControl();
            controlador.Morir();
            efectoMuerte.Play();
            //Invoke("cargarEscena", 2f);
        }*/
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //if (collision.gameObject.CompareTag("Pinchos") || collision.gameObject.CompareTag("Enemigo"))
        if (cuerpo.IsTouchingLayers(layersMuerte))
        {
            Debug.Log("¡El personaje colisiona a un enemigo!");
            //controlador.PararControl();
            controlador.Morir();
            efectoMuerte.Play();
            //Invoke("cargarEscena", 2f);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Background"))
        {
            controlador.Morir();
            //efectoMuerte.Play();
        }
    }

}
